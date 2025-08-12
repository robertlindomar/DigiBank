using DigiBank.models;
using DigiBank.services;
using System;
using System.Collections.Generic;

namespace DigiBank.controllers
{
    public class ContaController
    {
        private readonly ContaService _service;

        public ContaController()
        {
            _service = new ContaService();
        }

        public int Criar(Conta conta)
        {
            try
            {
                return _service.CriarConta(conta);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao criar conta: {ex.Message}");
            }
        }

        public List<Conta> BuscarTodas()
        {
            try
            {
                return _service.BuscarTodas();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar contas: {ex.Message}");
            }
        }

        public Conta BuscarPorId(int id)
        {
            try
            {
                return _service.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar conta por ID: {ex.Message}");
            }
        }

        public List<Conta> BuscarPorClienteId(int clienteId)
        {
            try
            {
                return _service.BuscarPorClienteId(clienteId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar contas do cliente: {ex.Message}");
            }
        }

        public Conta BuscarPorNumeroConta(string numeroConta)
        {
            try
            {
                return _service.BuscarPorNumeroConta(numeroConta);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar conta por número: {ex.Message}");
            }
        }

        public List<Conta> BuscarPorTipo(string tipo)
        {
            try
            {
                return _service.BuscarPorTipo(tipo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar contas por tipo: {ex.Message}");
            }
        }

        public void Atualizar(Conta conta)
        {
            try
            {
                _service.AtualizarConta(conta);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao atualizar conta: {ex.Message}");
            }
        }

        public void AtualizarSaldo(int contaId, decimal novoSaldo)
        {
            try
            {
                _service.AtualizarSaldo(contaId, novoSaldo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao atualizar saldo: {ex.Message}");
            }
        }

        public void Deletar(int id)
        {
            try
            {
                _service.DeletarConta(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao deletar conta: {ex.Message}");
            }
        }

        public void Desativar(int id)
        {
            try
            {
                _service.DesativarConta(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao desativar conta: {ex.Message}");
            }
        }

        public bool Existe(int id)
        {
            try
            {
                return _service.ExisteConta(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao verificar existência da conta: {ex.Message}");
            }
        }

        public bool ExisteNumeroConta(string numeroConta)
        {
            try
            {
                return _service.ExisteNumeroConta(numeroConta);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao verificar existência do número da conta: {ex.Message}");
            }
        }

        public decimal ObterSaldoTotal(int clienteId)
        {
            try
            {
                return _service.ObterSaldoTotal(clienteId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao obter saldo total: {ex.Message}");
            }
        }
    }
}
