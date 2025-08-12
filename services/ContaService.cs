using DigiBank.models;
using DigiBank.repositories;
using System;
using System.Collections.Generic;

namespace DigiBank.services
{
    public class ContaService
    {
        private readonly ContaRepository _repository;
        private readonly ClienteService _clienteService;

        public ContaService()
        {
            _repository = new ContaRepository();
            _clienteService = new ClienteService();
        }

        public int CriarConta(Conta novaConta)
        {
            try
            {
                ValidarConta(novaConta);

                // Verificar se o cliente existe
                if (!_clienteService.ExisteCliente(novaConta.ClienteId))
                {
                    throw new Exception("Cliente não encontrado.");
                }

                // Verificar se o número da conta já existe
                if (_repository.ExisteNumeroConta(novaConta.NumeroConta))
                {
                    throw new Exception("Número de conta já existe.");
                }

                return _repository.Criar(novaConta);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar conta: {ex.Message}");
            }
        }

        public List<Conta> BuscarTodas()
        {
            try
            {
                return _repository.BuscarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar contas: {ex.Message}");
            }
        }

        public Conta BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                return _repository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar conta por ID: {ex.Message}");
            }
        }

        public List<Conta> BuscarPorClienteId(int clienteId)
        {
            try
            {
                if (clienteId <= 0)
                    throw new ArgumentException("ID do cliente deve ser maior que zero.");

                return _repository.BuscarPorClienteId(clienteId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar contas do cliente: {ex.Message}");
            }
        }

        public Conta BuscarPorNumeroConta(string numeroConta)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(numeroConta))
                    throw new ArgumentException("Número da conta não pode ser vazio.");

                return _repository.BuscarPorNumeroConta(numeroConta);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar conta por número: {ex.Message}");
            }
        }

        public List<Conta> BuscarPorTipo(string tipo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tipo))
                    throw new ArgumentException("Tipo da conta não pode ser vazio.");

                if (!tipo.Equals("corrente", StringComparison.OrdinalIgnoreCase) &&
                    !tipo.Equals("poupanca", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Tipo de conta deve ser 'corrente' ou 'poupanca'.");
                }

                return _repository.BuscarPorTipo(tipo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar contas por tipo: {ex.Message}");
            }
        }

        public void AtualizarConta(Conta conta)
        {
            try
            {
                ValidarConta(conta);

                var existente = _repository.BuscarPorId(conta.Id);
                if (existente == null)
                {
                    throw new Exception("Conta não encontrada.");
                }

                // Verificar se o número da conta já existe em outra conta
                var contaComNumero = _repository.BuscarPorNumeroConta(conta.NumeroConta);
                if (contaComNumero != null && contaComNumero.Id != conta.Id)
                {
                    throw new Exception("Número de conta já existe para outra conta.");
                }

                _repository.Atualizar(conta);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar conta: {ex.Message}");
            }
        }

        public void AtualizarSaldo(int contaId, decimal novoSaldo)
        {
            try
            {
                if (contaId <= 0)
                    throw new ArgumentException("ID da conta deve ser maior que zero.");

                if (novoSaldo < 0)
                    throw new ArgumentException("Saldo não pode ser negativo.");

                var conta = _repository.BuscarPorId(contaId);
                if (conta == null)
                {
                    throw new Exception("Conta não encontrada.");
                }

                _repository.AtualizarSaldo(contaId, novoSaldo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar saldo: {ex.Message}");
            }
        }

        public void DeletarConta(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                var conta = _repository.BuscarPorId(id);
                if (conta == null)
                {
                    throw new Exception("Conta não encontrada.");
                }

                _repository.Deletar(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar conta: {ex.Message}");
            }
        }

        public void DesativarConta(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                var conta = _repository.BuscarPorId(id);
                if (conta == null)
                {
                    throw new Exception("Conta não encontrada.");
                }

                _repository.Desativar(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao desativar conta: {ex.Message}");
            }
        }

        public bool ExisteConta(int id)
        {
            try
            {
                return _repository.BuscarPorId(id) != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar existência da conta: {ex.Message}");
            }
        }

        public bool ExisteNumeroConta(string numeroConta)
        {
            try
            {
                return _repository.ExisteNumeroConta(numeroConta);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar existência do número da conta: {ex.Message}");
            }
        }

        public decimal ObterSaldoTotal(int clienteId)
        {
            try
            {
                if (clienteId <= 0)
                    throw new ArgumentException("ID do cliente deve ser maior que zero.");

                var contas = _repository.BuscarPorClienteId(clienteId);
                decimal saldoTotal = 0;

                foreach (var conta in contas)
                {
                    saldoTotal += conta.Saldo;
                }

                return saldoTotal;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter saldo total: {ex.Message}");
            }
        }

        private void ValidarConta(Conta conta)
        {
            if (conta == null)
                throw new ArgumentNullException(nameof(conta), "Conta não pode ser nula.");

            if (string.IsNullOrWhiteSpace(conta.NumeroConta))
                throw new ArgumentException("Número da conta é obrigatório.");

            if (string.IsNullOrWhiteSpace(conta.Tipo))
                throw new ArgumentException("Tipo da conta é obrigatório.");

            if (conta.ClienteId <= 0)
                throw new ArgumentException("ID do cliente deve ser maior que zero.");

            if (conta.NumeroConta.Length < 3)
                throw new ArgumentException("Número da conta deve ter pelo menos 3 caracteres.");

            if (!conta.Tipo.Equals("corrente", StringComparison.OrdinalIgnoreCase) &&
                !conta.Tipo.Equals("poupanca", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Tipo de conta deve ser 'corrente' ou 'poupanca'.");
            }
        }
    }
}
