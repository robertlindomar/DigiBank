using DigiBank.models;
using DigiBank.repositories;
using System;
using System.Collections.Generic;

namespace DigiBank.services
{
    public class TransacaoService
    {
        private readonly TransacaoRepository _repository;
        private readonly ContaService _contaService;

        public TransacaoService()
        {
            _repository = new TransacaoRepository();
            _contaService = new ContaService();
        }

        public int CriarTransacao(Transacao novaTransacao)
        {
            try
            {
                ValidarTransacao(novaTransacao);

                // Verificar se as contas existem
                if (novaTransacao.ContaOrigemId.HasValue && !_contaService.ExisteConta(novaTransacao.ContaOrigemId.Value))
                {
                    throw new Exception("Conta de origem não encontrada.");
                }

                if (novaTransacao.ContaDestinoId.HasValue && !_contaService.ExisteConta(novaTransacao.ContaDestinoId.Value))
                {
                    throw new Exception("Conta de destino não encontrada.");
                }

                // Validar regras de negócio específicas por tipo
                ValidarRegrasNegocio(novaTransacao);

                return _repository.Criar(novaTransacao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar transação: {ex.Message}");
            }
        }

        public List<Transacao> BuscarTodas()
        {
            try
            {
                return _repository.BuscarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar transações: {ex.Message}");
            }
        }

        public Transacao BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                return _repository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar transação por ID: {ex.Message}");
            }
        }

        public List<Transacao> BuscarPorContaId(int contaId)
        {
            try
            {
                if (contaId <= 0)
                    throw new ArgumentException("ID da conta deve ser maior que zero.");

                return _repository.BuscarPorContaId(contaId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar transações da conta: {ex.Message}");
            }
        }

        public List<Transacao> BuscarPorClienteId(int clienteId)
        {
            try
            {
                if (clienteId <= 0)
                    throw new ArgumentException("ID do cliente deve ser maior que zero.");

                return _repository.BuscarPorClienteId(clienteId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar transações do cliente: {ex.Message}");
            }
        }

        public List<Transacao> BuscarPorTipo(string tipo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tipo))
                    throw new ArgumentException("Tipo não pode ser vazio.");

                if (!tipo.Equals("deposito", StringComparison.OrdinalIgnoreCase) &&
                    !tipo.Equals("saque", StringComparison.OrdinalIgnoreCase) &&
                    !tipo.Equals("transferencia", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Tipo deve ser 'deposito', 'saque' ou 'transferencia'.");
                }

                return _repository.BuscarPorTipo(tipo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar transações por tipo: {ex.Message}");
            }
        }

        public List<Transacao> BuscarPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                if (dataInicio > dataFim)
                    throw new ArgumentException("Data de início deve ser menor que data de fim.");

                return _repository.BuscarPorPeriodo(dataInicio, dataFim);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar transações por período: {ex.Message}");
            }
        }

        public List<Transacao> BuscarPorValor(decimal valorMinimo, decimal valorMaximo)
        {
            try
            {
                if (valorMinimo < 0)
                    throw new ArgumentException("Valor mínimo não pode ser negativo.");

                if (valorMaximo < valorMinimo)
                    throw new ArgumentException("Valor máximo deve ser maior que valor mínimo.");

                return _repository.BuscarPorValor(valorMinimo, valorMaximo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar transações por valor: {ex.Message}");
            }
        }

        public void AtualizarTransacao(Transacao transacao)
        {
            try
            {
                ValidarTransacao(transacao);

                var existente = _repository.BuscarPorId(transacao.Id);
                if (existente == null)
                {
                    throw new Exception("Transação não encontrada.");
                }

                _repository.Atualizar(transacao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar transação: {ex.Message}");
            }
        }

        public void DeletarTransacao(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                var transacao = _repository.BuscarPorId(id);
                if (transacao == null)
                {
                    throw new Exception("Transação não encontrada.");
                }

                _repository.Deletar(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar transação: {ex.Message}");
            }
        }

        public bool ExisteTransacao(int id)
        {
            try
            {
                return _repository.BuscarPorId(id) != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar existência da transação: {ex.Message}");
            }
        }

        public decimal ObterSaldoTotalPorConta(int contaId)
        {
            try
            {
                if (contaId <= 0)
                    throw new ArgumentException("ID da conta deve ser maior que zero.");

                return _repository.ObterSaldoTotalPorConta(contaId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter saldo total: {ex.Message}");
            }
        }

        public int RealizarDeposito(int contaId, decimal valor, string descricao = null)
        {
            try
            {
                if (contaId <= 0)
                    throw new ArgumentException("ID da conta deve ser maior que zero.");

                if (valor <= 0)
                    throw new ArgumentException("Valor do depósito deve ser maior que zero.");

                var conta = _contaService.BuscarPorId(contaId);
                if (conta == null)
                {
                    throw new Exception("Conta não encontrada.");
                }

                var transacao = new Transacao
                {
                    Tipo = "deposito",
                    Valor = valor,
                    ContaDestinoId = contaId,
                    Descricao = descricao ?? "Depósito"
                };

                int transacaoId = _repository.Criar(transacao);

                // Atualizar saldo da conta
                decimal novoSaldo = conta.Saldo + valor;
                _contaService.AtualizarSaldo(contaId, novoSaldo);

                return transacaoId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao realizar depósito: {ex.Message}");
            }
        }

        public int RealizarSaque(int contaId, decimal valor, string descricao = null)
        {
            try
            {
                if (contaId <= 0)
                    throw new ArgumentException("ID da conta deve ser maior que zero.");

                if (valor <= 0)
                    throw new ArgumentException("Valor do saque deve ser maior que zero.");

                var conta = _contaService.BuscarPorId(contaId);
                if (conta == null)
                {
                    throw new Exception("Conta não encontrada.");
                }

                if (conta.Saldo < valor)
                {
                    throw new Exception("Saldo insuficiente para realizar o saque.");
                }

                var transacao = new Transacao
                {
                    Tipo = "saque",
                    Valor = valor,
                    ContaOrigemId = contaId,
                    Descricao = descricao ?? "Saque"
                };

                int transacaoId = _repository.Criar(transacao);

                // Atualizar saldo da conta
                decimal novoSaldo = conta.Saldo - valor;
                _contaService.AtualizarSaldo(contaId, novoSaldo);

                return transacaoId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao realizar saque: {ex.Message}");
            }
        }

        public int RealizarTransferencia(int contaOrigemId, int contaDestinoId, decimal valor, string descricao = null)
        {
            try
            {
                if (contaOrigemId <= 0)
                    throw new ArgumentException("ID da conta de origem deve ser maior que zero.");

                if (contaDestinoId <= 0)
                    throw new ArgumentException("ID da conta de destino deve ser maior que zero.");

                if (contaOrigemId == contaDestinoId)
                    throw new ArgumentException("Conta de origem e destino não podem ser iguais.");

                if (valor <= 0)
                    throw new ArgumentException("Valor da transferência deve ser maior que zero.");

                var contaOrigem = _contaService.BuscarPorId(contaOrigemId);
                if (contaOrigem == null)
                {
                    throw new Exception("Conta de origem não encontrada.");
                }

                var contaDestino = _contaService.BuscarPorId(contaDestinoId);
                if (contaDestino == null)
                {
                    throw new Exception("Conta de destino não encontrada.");
                }

                if (contaOrigem.Saldo < valor)
                {
                    throw new Exception("Saldo insuficiente para realizar a transferência.");
                }

                var transacao = new Transacao
                {
                    Tipo = "transferencia",
                    Valor = valor,
                    ContaOrigemId = contaOrigemId,
                    ContaDestinoId = contaDestinoId,
                    Descricao = descricao ?? "Transferência"
                };

                int transacaoId = _repository.Criar(transacao);

                // Atualizar saldos das contas
                decimal novoSaldoOrigem = contaOrigem.Saldo - valor;
                decimal novoSaldoDestino = contaDestino.Saldo + valor;

                _contaService.AtualizarSaldo(contaOrigemId, novoSaldoOrigem);
                _contaService.AtualizarSaldo(contaDestinoId, novoSaldoDestino);

                return transacaoId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao realizar transferência: {ex.Message}");
            }
        }

        private void ValidarTransacao(Transacao transacao)
        {
            if (transacao == null)
                throw new ArgumentNullException(nameof(transacao), "Transação não pode ser nula.");

            if (string.IsNullOrWhiteSpace(transacao.Tipo))
                throw new ArgumentException("Tipo da transação é obrigatório.");

            if (transacao.Valor <= 0)
                throw new ArgumentException("Valor da transação deve ser maior que zero.");

            if (!transacao.Tipo.Equals("deposito", StringComparison.OrdinalIgnoreCase) &&
                !transacao.Tipo.Equals("saque", StringComparison.OrdinalIgnoreCase) &&
                !transacao.Tipo.Equals("transferencia", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Tipo deve ser 'deposito', 'saque' ou 'transferencia'.");
            }
        }

        private void ValidarRegrasNegocio(Transacao transacao)
        {
            switch (transacao.Tipo.ToLower())
            {
                case "deposito":
                    if (transacao.ContaOrigemId.HasValue)
                        throw new Exception("Depósito não pode ter conta de origem.");
                    if (!transacao.ContaDestinoId.HasValue)
                        throw new Exception("Depósito deve ter conta de destino.");
                    break;

                case "saque":
                    if (!transacao.ContaOrigemId.HasValue)
                        throw new Exception("Saque deve ter conta de origem.");
                    if (transacao.ContaDestinoId.HasValue)
                        throw new Exception("Saque não pode ter conta de destino.");
                    break;

                case "transferencia":
                    if (!transacao.ContaOrigemId.HasValue)
                        throw new Exception("Transferência deve ter conta de origem.");
                    if (!transacao.ContaDestinoId.HasValue)
                        throw new Exception("Transferência deve ter conta de destino.");
                    if (transacao.ContaOrigemId == transacao.ContaDestinoId)
                        throw new Exception("Conta de origem e destino não podem ser iguais.");
                    break;
            }
        }
    }
}
