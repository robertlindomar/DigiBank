using DigiBank.models;
using DigiBank.services;
using System;
using System.Collections.Generic;

namespace DigiBank.controllers
{
    public class TransacaoController
    {
        private readonly TransacaoService _service;

        public TransacaoController()
        {
            _service = new TransacaoService();
        }

        public int Criar(Transacao transacao)
        {
            try
            {
                return _service.CriarTransacao(transacao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao criar transação: {ex.Message}");
            }
        }

        public List<Transacao> BuscarTodas()
        {
            try
            {
                return _service.BuscarTodas();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar transações: {ex.Message}");
            }
        }

        public Transacao BuscarPorId(int id)
        {
            try
            {
                return _service.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar transação por ID: {ex.Message}");
            }
        }

        public List<Transacao> BuscarPorContaId(int contaId)
        {
            try
            {
                return _service.BuscarPorContaId(contaId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar transações da conta: {ex.Message}");
            }
        }

        public List<Transacao> BuscarPorClienteId(int clienteId)
        {
            try
            {
                return _service.BuscarPorClienteId(clienteId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar transações do cliente: {ex.Message}");
            }
        }

        public List<Transacao> BuscarPorTipo(string tipo)
        {
            try
            {
                return _service.BuscarPorTipo(tipo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar transações por tipo: {ex.Message}");
            }
        }

        public List<Transacao> BuscarPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                return _service.BuscarPorPeriodo(dataInicio, dataFim);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar transações por período: {ex.Message}");
            }
        }

        public List<Transacao> BuscarPorValor(decimal valorMinimo, decimal valorMaximo)
        {
            try
            {
                return _service.BuscarPorValor(valorMinimo, valorMaximo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar transações por valor: {ex.Message}");
            }
        }

        public void Atualizar(Transacao transacao)
        {
            try
            {
                _service.AtualizarTransacao(transacao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao atualizar transação: {ex.Message}");
            }
        }

        public void Deletar(int id)
        {
            try
            {
                _service.DeletarTransacao(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao deletar transação: {ex.Message}");
            }
        }

        public bool Existe(int id)
        {
            try
            {
                return _service.ExisteTransacao(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao verificar existência da transação: {ex.Message}");
            }
        }

        public decimal ObterSaldoTotalPorConta(int contaId)
        {
            try
            {
                return _service.ObterSaldoTotalPorConta(contaId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao obter saldo total: {ex.Message}");
            }
        }

        public int RealizarDeposito(int contaId, decimal valor, string descricao = null)
        {
            try
            {
                return _service.RealizarDeposito(contaId, valor, descricao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao realizar depósito: {ex.Message}");
            }
        }

        public int RealizarSaque(int contaId, decimal valor, string descricao = null)
        {
            try
            {
                return _service.RealizarSaque(contaId, valor, descricao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao realizar saque: {ex.Message}");
            }
        }

        public int RealizarTransferencia(int contaOrigemId, int contaDestinoId, decimal valor, string descricao = null)
        {
            try
            {
                return _service.RealizarTransferencia(contaOrigemId, contaDestinoId, valor, descricao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao realizar transferência: {ex.Message}");
            }
        }
    }
}
