using DigiBank.models;
using DigiBank.repositories;
using System;
using System.Collections.Generic;

namespace DigiBank.services
{
    public class CartaoService
    {
        private readonly CartaoRepository _repository;
        private readonly ContaService _contaService;

        public CartaoService()
        {
            _repository = new CartaoRepository();
            _contaService = new ContaService();
        }

        public int CriarCartao(CartaoNfc novoCartao)
        {
            try
            {
                ValidarCartao(novoCartao);

                // Verificar se a conta existe
                if (!_contaService.ExisteConta(novoCartao.ContaId))
                {
                    throw new Exception("Conta não encontrada.");
                }

                // Verificar se o UID já existe
                if (_repository.ExisteUid(novoCartao.Uid))
                {
                    throw new Exception("UID do cartão já existe.");
                }

                return _repository.Criar(novoCartao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar cartão: {ex.Message}");
            }
        }

        public List<CartaoNfc> BuscarTodos()
        {
            try
            {
                return _repository.BuscarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar cartões: {ex.Message}");
            }
        }

        public CartaoNfc BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                return _repository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar cartão por ID: {ex.Message}");
            }
        }

        public CartaoNfc BuscarPorUid(string uid)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(uid))
                    throw new ArgumentException("UID não pode ser vazio.");

                return _repository.BuscarPorUid(uid);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar cartão por UID: {ex.Message}");
            }
        }

        public List<CartaoNfc> BuscarPorContaId(int contaId)
        {
            try
            {
                if (contaId <= 0)
                    throw new ArgumentException("ID da conta deve ser maior que zero.");

                return _repository.BuscarPorContaId(contaId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar cartões da conta: {ex.Message}");
            }
        }

        public List<CartaoNfc> BuscarPorClienteId(int clienteId)
        {
            try
            {
                if (clienteId <= 0)
                    throw new ArgumentException("ID do cliente deve ser maior que zero.");

                return _repository.BuscarPorClienteId(clienteId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar cartões do cliente: {ex.Message}");
            }
        }

        public void AtualizarCartao(CartaoNfc cartao)
        {
            try
            {
                ValidarCartao(cartao);

                var existente = _repository.BuscarPorId(cartao.Id);
                if (existente == null)
                {
                    throw new Exception("Cartão não encontrado.");
                }

                // Verificar se o UID já existe em outro cartão
                var cartaoComUid = _repository.BuscarPorUid(cartao.Uid);
                if (cartaoComUid != null && cartaoComUid.Id != cartao.Id)
                {
                    throw new Exception("UID já existe para outro cartão.");
                }

                _repository.Atualizar(cartao);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar cartão: {ex.Message}");
            }
        }

        public void AtualizarPin(int id, string novoPinHash)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                if (string.IsNullOrWhiteSpace(novoPinHash))
                    throw new ArgumentException("Novo PIN não pode ser vazio.");

                var cartao = _repository.BuscarPorId(id);
                if (cartao == null)
                {
                    throw new Exception("Cartão não encontrado.");
                }

                _repository.AtualizarPin(id, novoPinHash);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar PIN: {ex.Message}");
            }
        }

        public void DeletarCartao(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                var cartao = _repository.BuscarPorId(id);
                if (cartao == null)
                {
                    throw new Exception("Cartão não encontrado.");
                }

                _repository.Deletar(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar cartão: {ex.Message}");
            }
        }

        public void DesativarCartao(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                var cartao = _repository.BuscarPorId(id);
                if (cartao == null)
                {
                    throw new Exception("Cartão não encontrado.");
                }

                _repository.Desativar(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao desativar cartão: {ex.Message}");
            }
        }

        public bool ExisteCartao(int id)
        {
            try
            {
                return _repository.BuscarPorId(id) != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar existência do cartão: {ex.Message}");
            }
        }

        public bool ExisteUid(string uid)
        {
            try
            {
                return _repository.ExisteUid(uid);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar existência do UID: {ex.Message}");
            }
        }

        public bool ValidarPin(int cartaoId, string pinHash)
        {
            try
            {
                if (cartaoId <= 0)
                    throw new ArgumentException("ID do cartão deve ser maior que zero.");

                if (string.IsNullOrWhiteSpace(pinHash))
                    throw new ArgumentException("PIN não pode ser vazio.");

                return _repository.ValidarPin(cartaoId, pinHash);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao validar PIN: {ex.Message}");
            }
        }

        public CartaoNfc AutenticarPorUid(string uid)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(uid))
                    throw new ArgumentException("UID não pode ser vazio.");

                var cartao = _repository.BuscarPorUid(uid);
                if (cartao == null)
                {
                    throw new Exception("Cartão não encontrado.");
                }

                if (!cartao.Ativo)
                {
                    throw new Exception("Cartão está inativo.");
                }

                return cartao;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao autenticar cartão: {ex.Message}");
            }
        }

        private void ValidarCartao(CartaoNfc cartao)
        {
            if (cartao == null)
                throw new ArgumentNullException(nameof(cartao), "Cartão não pode ser nulo.");

            if (string.IsNullOrWhiteSpace(cartao.Uid))
                throw new ArgumentException("UID é obrigatório.");

            if (cartao.ContaId <= 0)
                throw new ArgumentException("ID da conta deve ser maior que zero.");

            if (cartao.Uid.Length < 5)
                throw new ArgumentException("UID deve ter pelo menos 5 caracteres.");
        }
    }
}
