using DigiBank.models;
using DigiBank.services;
using System;
using System.Collections.Generic;

namespace DigiBank.controllers
{
    public class ClienteController
    {
        private readonly ClienteService _service;

        public ClienteController()
        {
            _service = new ClienteService();
        }

        public int Criar(Cliente cliente)
        {
            try
            {
                return _service.CadastrarCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao criar cliente: {ex.Message}");
            }
        }

        public List<Cliente> BuscarTodos()
        {
            try
            {
                return _service.BuscarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar clientes: {ex.Message}");
            }
        }

        public Cliente BuscarPorId(int id)
        {
            try
            {
                return _service.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar cliente por ID: {ex.Message}");
            }
        }

        public Cliente BuscarPorCpf(string cpf)
        {
            try
            {
                return _service.BuscarPorCpf(cpf);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar cliente por CPF: {ex.Message}");
            }
        }

        public List<Cliente> BuscarPorNome(string nome)
        {
            try
            {
                return _service.BuscarPorNome(nome);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar clientes por nome: {ex.Message}");
            }
        }

        public void Atualizar(Cliente cliente)
        {
            try
            {
                _service.AtualizarCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao atualizar cliente: {ex.Message}");
            }
        }

        public void Deletar(int id)
        {
            try
            {
                _service.DeletarCliente(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao deletar cliente: {ex.Message}");
            }
        }

        public bool Existe(int id)
        {
            try
            {
                return _service.ExisteCliente(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao verificar existência do cliente: {ex.Message}");
            }
        }

        public bool ExisteCpf(string cpf)
        {
            try
            {
                return _service.ExisteCpf(cpf);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao verificar existência do CPF: {ex.Message}");
            }
        }

        public Cliente BuscarPorLogin(string login)
        {
            try
            {
                return _service.BuscarPorLogin(login);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar cliente por login: {ex.Message}");
            }
        }

        public List<Cliente> BuscarPorTipo(string tipo)
        {
            try
            {
                return _service.BuscarPorTipo(tipo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar clientes por tipo: {ex.Message}");
            }
        }

        public void Ativar(int id)
        {
            try
            {
                _service.AtivarCliente(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao ativar cliente: {ex.Message}");
            }
        }

        public void Desativar(int id)
        {
            try
            {
                _service.DesativarCliente(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao desativar cliente: {ex.Message}");
            }
        }

        public Cliente FazerLogin(string login, string senha)
        {
            try
            {
                return _service.FazerLogin(login, senha);
            }
            catch (Exception ex)
            {
                throw new Exception($" Erro no controller ao fazer login: {ex.Message}");
            }
        }
    }
}
