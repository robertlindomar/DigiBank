using DigiBank.models;
using DigiBank.services;
using System;
using System.Collections.Generic;

namespace DigiBank.controllers
{
    public class PagamentoPosController
    {
        private readonly PagamentoPosService _service;

        public PagamentoPosController()
        {
            _service = new PagamentoPosService();
        }

        public int Criar(PagamentoPos pagamento)
        {
            try
            {
                return _service.CriarPagamento(pagamento);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao criar pagamento: {ex.Message}");
            }
        }

        public List<PagamentoPos> BuscarTodos()
        {
            try
            {
                return _service.BuscarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar pagamentos: {ex.Message}");
            }
        }

        public PagamentoPos BuscarPorId(int id)
        {
            try
            {
                return _service.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar pagamento por ID: {ex.Message}");
            }
        }

        public List<PagamentoPos> BuscarPorTerminalId(int terminalId)
        {
            try
            {
                return _service.BuscarPorTerminalId(terminalId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar pagamentos do terminal: {ex.Message}");
            }
        }

        public List<PagamentoPos> BuscarPorCartaoId(int cartaoId)
        {
            try
            {
                return _service.BuscarPorCartaoId(cartaoId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar pagamentos do cartão: {ex.Message}");
            }
        }

        public List<PagamentoPos> BuscarPorStatus(string status)
        {
            try
            {
                return _service.BuscarPorStatus(status);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar pagamentos por status: {ex.Message}");
            }
        }

        public List<PagamentoPos> BuscarPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                return _service.BuscarPorPeriodo(dataInicio, dataFim);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar pagamentos por período: {ex.Message}");
            }
        }

        public List<PagamentoPos> BuscarPorValor(decimal valorMinimo, decimal valorMaximo)
        {
            try
            {
                return _service.BuscarPorValor(valorMinimo, valorMaximo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar pagamentos por valor: {ex.Message}");
            }
        }

        public void Atualizar(PagamentoPos pagamento)
        {
            try
            {
                _service.AtualizarPagamento(pagamento);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao atualizar pagamento: {ex.Message}");
            }
        }

        public void AtualizarStatus(int id, string novoStatus)
        {
            try
            {
                _service.AtualizarStatus(id, novoStatus);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao atualizar status: {ex.Message}");
            }
        }

        public void Deletar(int id)
        {
            try
            {
                _service.DeletarPagamento(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao deletar pagamento: {ex.Message}");
            }
        }

        public bool Existe(int id)
        {
            try
            {
                return _service.ExistePagamento(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao verificar existência do pagamento: {ex.Message}");
            }
        }

        public decimal ObterTotalVendidoPorTerminal(int terminalId, DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                return _service.ObterTotalVendidoPorTerminal(terminalId, dataInicio, dataFim);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao obter total vendido: {ex.Message}");
            }
        }

        public int ProcessarPagamento(int terminalId, int cartaoId, decimal valor, string descricao = null)
        {
            try
            {
                return _service.ProcessarPagamento(terminalId, cartaoId, valor, descricao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao processar pagamento: {ex.Message}");
            }
        }
    }
}
