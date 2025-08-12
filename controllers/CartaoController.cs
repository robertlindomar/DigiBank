using DigiBank.models;
using DigiBank.services;
using System;
using System.Collections.Generic;

namespace DigiBank.controllers
{
    public class CartaoController
    {
        private readonly CartaoService _service;

        public CartaoController()
        {
            _service = new CartaoService();
        }

        public int Criar(CartaoNfc cartao)
        {
            try
            {
                return _service.CriarCartao(cartao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao criar cartão: {ex.Message}");
            }
        }

        public List<CartaoNfc> BuscarTodos()
        {
            try
            {
                return _service.BuscarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar cartões: {ex.Message}");
            }
        }

        public CartaoNfc BuscarPorId(int id)
        {
            try
            {
                return _service.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar cartão por ID: {ex.Message}");
            }
        }

        public CartaoNfc BuscarPorUid(string uid)
        {
            try
            {
                return _service.BuscarPorUid(uid);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar cartão por UID: {ex.Message}");
            }
        }

        public List<CartaoNfc> BuscarPorContaId(int contaId)
        {
            try
            {
                return _service.BuscarPorContaId(contaId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar cartões da conta: {ex.Message}");
            }
        }

        public List<CartaoNfc> BuscarPorClienteId(int clienteId)
        {
            try
            {
                return _service.BuscarPorClienteId(clienteId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar cartões do cliente: {ex.Message}");
            }
        }

        public void Atualizar(CartaoNfc cartao)
        {
            try
            {
                _service.AtualizarCartao(cartao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao atualizar cartão: {ex.Message}");
            }
        }

        public void AtualizarPin(int id, string novoPinHash)
        {
            try
            {
                _service.AtualizarPin(id, novoPinHash);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao atualizar PIN: {ex.Message}");
            }
        }

        public void Deletar(int id)
        {
            try
            {
                _service.DeletarCartao(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao deletar cartão: {ex.Message}");
            }
        }

        public void Desativar(int id)
        {
            try
            {
                _service.DesativarCartao(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao desativar cartão: {ex.Message}");
            }
        }

        public bool Existe(int id)
        {
            try
            {
                return _service.ExisteCartao(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao verificar existência do cartão: {ex.Message}");
            }
        }

        public bool ExisteUid(string uid)
        {
            try
            {
                return _service.ExisteUid(uid);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao verificar existência do UID: {ex.Message}");
            }
        }

        public bool ValidarPin(int cartaoId, string pinHash)
        {
            try
            {
                return _service.ValidarPin(cartaoId, pinHash);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao validar PIN: {ex.Message}");
            }
        }

        public CartaoNfc AutenticarPorUid(string uid)
        {
            try
            {
                return _service.AutenticarPorUid(uid);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao autenticar cartão: {ex.Message}");
            }
        }
    }
}
