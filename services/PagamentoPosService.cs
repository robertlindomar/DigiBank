using DigiBank.models;
using DigiBank.repositories;
using System;
using System.Collections.Generic;

namespace DigiBank.services
{
    public class PagamentoPosService
    {
        private readonly PagamentoPosRepository _repository;
        private readonly TerminalPosService _terminalService;
        private readonly CartaoService _cartaoService;
        private readonly ContaService _contaService;

        public PagamentoPosService()
        {
            _repository = new PagamentoPosRepository();
            _terminalService = new TerminalPosService();
            _cartaoService = new CartaoService();
            _contaService = new ContaService();
        }

        public int CriarPagamento(PagamentoPos novoPagamento)
        {
            try
            {
                ValidarPagamento(novoPagamento);
                
                // Verificar se o terminal existe (se fornecido)
                if (novoPagamento.TerminalId.HasValue && !_terminalService.ExisteTerminal(novoPagamento.TerminalId.Value))
                {
                    throw new Exception("Terminal não encontrado.");
                }

                // Verificar se o cartão existe (se fornecido)
                if (novoPagamento.CartaoId.HasValue && !_cartaoService.ExisteCartao(novoPagamento.CartaoId.Value))
                {
                    throw new Exception("Cartão não encontrado.");
                }

                return _repository.Criar(novoPagamento);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar pagamento: {ex.Message}");
            }
        }

        public List<PagamentoPos> BuscarTodos()
        {
            try
            {
                return _repository.BuscarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar pagamentos: {ex.Message}");
            }
        }

        public PagamentoPos BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                return _repository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar pagamento por ID: {ex.Message}");
            }
        }

        public List<PagamentoPos> BuscarPorTerminalId(int terminalId)
        {
            try
            {
                if (terminalId <= 0)
                    throw new ArgumentException("ID do terminal deve ser maior que zero.");

                return _repository.BuscarPorTerminalId(terminalId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar pagamentos do terminal: {ex.Message}");
            }
        }

        public List<PagamentoPos> BuscarPorCartaoId(int cartaoId)
        {
            try
            {
                if (cartaoId <= 0)
                    throw new ArgumentException("ID do cartão deve ser maior que zero.");

                return _repository.BuscarPorCartaoId(cartaoId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar pagamentos do cartão: {ex.Message}");
            }
        }

        public List<PagamentoPos> BuscarPorStatus(string status)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(status))
                    throw new ArgumentException("Status não pode ser vazio.");

                if (!status.Equals("aprovado", StringComparison.OrdinalIgnoreCase) && 
                    !status.Equals("recusado", StringComparison.OrdinalIgnoreCase) && 
                    !status.Equals("pin_incorreto", StringComparison.OrdinalIgnoreCase) && 
                    !status.Equals("saldo_insuficiente", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Status deve ser 'aprovado', 'recusado', 'pin_incorreto' ou 'saldo_insuficiente'.");
                }

                return _repository.BuscarPorStatus(status);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar pagamentos por status: {ex.Message}");
            }
        }

        public List<PagamentoPos> BuscarPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                if (dataInicio > dataFim)
                    throw new ArgumentException("Data de início deve ser menor que data de fim.");

                return _repository.BuscarPorPeriodo(dataInicio, dataFim);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar pagamentos por período: {ex.Message}");
            }
        }

        public List<PagamentoPos> BuscarPorValor(decimal valorMinimo, decimal valorMaximo)
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
                throw new Exception($"Erro ao buscar pagamentos por valor: {ex.Message}");
            }
        }

        public void AtualizarPagamento(PagamentoPos pagamento)
        {
            try
            {
                ValidarPagamento(pagamento);
                
                var existente = _repository.BuscarPorId(pagamento.Id);
                if (existente == null)
                {
                    throw new Exception("Pagamento não encontrado.");
                }

                _repository.Atualizar(pagamento);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar pagamento: {ex.Message}");
            }
        }

        public void AtualizarStatus(int id, string novoStatus)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                if (string.IsNullOrWhiteSpace(novoStatus))
                    throw new ArgumentException("Novo status não pode ser vazio.");

                if (!novoStatus.Equals("aprovado", StringComparison.OrdinalIgnoreCase) && 
                    !novoStatus.Equals("recusado", StringComparison.OrdinalIgnoreCase) && 
                    !novoStatus.Equals("pin_incorreto", StringComparison.OrdinalIgnoreCase) && 
                    !novoStatus.Equals("saldo_insuficiente", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Status deve ser 'aprovado', 'recusado', 'pin_incorreto' ou 'saldo_insuficiente'.");
                }

                var pagamento = _repository.BuscarPorId(id);
                if (pagamento == null)
                {
                    throw new Exception("Pagamento não encontrado.");
                }

                _repository.AtualizarStatus(id, novoStatus);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar status: {ex.Message}");
            }
        }

        public void DeletarPagamento(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                var pagamento = _repository.BuscarPorId(id);
                if (pagamento == null)
                {
                    throw new Exception("Pagamento não encontrado.");
                }

                _repository.Deletar(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar pagamento: {ex.Message}");
            }
        }

        public bool ExistePagamento(int id)
        {
            try
            {
                return _repository.BuscarPorId(id) != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar existência do pagamento: {ex.Message}");
            }
        }

        public decimal ObterTotalVendidoPorTerminal(int terminalId, DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                if (terminalId <= 0)
                    throw new ArgumentException("ID do terminal deve ser maior que zero.");

                if (dataInicio > dataFim)
                    throw new ArgumentException("Data de início deve ser menor que data de fim.");

                return _repository.ObterTotalVendidoPorTerminal(terminalId, dataInicio, dataFim);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter total vendido: {ex.Message}");
            }
        }

        public int ProcessarPagamento(int terminalId, int cartaoId, decimal valor, string descricao = null)
        {
            try
            {
                if (terminalId <= 0)
                    throw new ArgumentException("ID do terminal deve ser maior que zero.");

                if (cartaoId <= 0)
                    throw new ArgumentException("ID do cartão deve ser maior que zero.");

                if (valor <= 0)
                    throw new ArgumentException("Valor deve ser maior que zero.");

                // Verificar se o terminal existe
                var terminal = _terminalService.BuscarPorId(terminalId);
                if (terminal == null)
                {
                    throw new Exception("Terminal não encontrado.");
                }

                // Verificar se o cartão existe e está ativo
                var cartao = _cartaoService.BuscarPorId(cartaoId);
                if (cartao == null)
                {
                    throw new Exception("Cartão não encontrado.");
                }

                if (!cartao.Ativo)
                {
                    throw new Exception("Cartão está inativo.");
                }

                // Verificar se há saldo suficiente na conta
                var conta = _contaService.BuscarPorId(cartao.ContaId);
                if (conta == null)
                {
                    throw new Exception("Conta não encontrada.");
                }

                if (conta.Saldo < valor)
                {
                    // Criar pagamento com status de saldo insuficiente
                    var pagamentoRecusado = new PagamentoPos
                    {
                        TerminalId = terminalId,
                        CartaoId = cartaoId,
                        Valor = valor,
                        Status = "saldo_insuficiente",
                        Descricao = descricao ?? "Pagamento recusado - Saldo insuficiente"
                    };

                    return _repository.Criar(pagamentoRecusado);
                }

                // Processar pagamento aprovado
                var pagamento = new PagamentoPos
                {
                    TerminalId = terminalId,
                    CartaoId = cartaoId,
                    Valor = valor,
                    Status = "aprovado",
                    Descricao = descricao ?? "Pagamento aprovado"
                };

                int pagamentoId = _repository.Criar(pagamento);

                // Atualizar saldo da conta
                decimal novoSaldo = conta.Saldo - valor;
                _contaService.AtualizarSaldo(conta.Id, novoSaldo);

                return pagamentoId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao processar pagamento: {ex.Message}");
            }
        }

        private void ValidarPagamento(PagamentoPos pagamento)
        {
            if (pagamento == null)
                throw new ArgumentNullException(nameof(pagamento), "Pagamento não pode ser nulo.");

            if (pagamento.Valor <= 0)
                throw new ArgumentException("Valor deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(pagamento.Status))
                throw new ArgumentException("Status é obrigatório.");

            if (!pagamento.Status.Equals("aprovado", StringComparison.OrdinalIgnoreCase) && 
                !pagamento.Status.Equals("recusado", StringComparison.OrdinalIgnoreCase) && 
                !pagamento.Status.Equals("pin_incorreto", StringComparison.OrdinalIgnoreCase) && 
                !pagamento.Status.Equals("saldo_insuficiente", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Status deve ser 'aprovado', 'recusado', 'pin_incorreto' ou 'saldo_insuficiente'.");
            }
        }
    }
}
