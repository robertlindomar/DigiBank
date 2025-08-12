using DigiBank.models;
using DigiBank.repositories;
using System;
using System.Collections.Generic;

namespace DigiBank.services
{
    public class ClienteService
    {
        private readonly ClienteRepository _repository;

        public ClienteService()
        {
            _repository = new ClienteRepository();
        }

        public int CadastrarCliente(Cliente novoCliente)
        {
            try
            {
                ValidarCliente(novoCliente);

                var existente = _repository.BuscarPorCpf(novoCliente.Cpf);
                if (existente != null)
                {
                    throw new Exception("CPF já cadastrado.");
                }

                return _repository.Criar(novoCliente);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao cadastrar cliente: {ex.Message}");
            }
        }

        public List<Cliente> BuscarTodos()
        {
            try
            {
                return _repository.BuscarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar clientes: {ex.Message}");
            }
        }

        public Cliente BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                return _repository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar cliente por ID: {ex.Message}");
            }
        }

        public Cliente BuscarPorCpf(string cpf)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cpf))
                    throw new ArgumentException("CPF não pode ser vazio.");

                return _repository.BuscarPorCpf(cpf);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar cliente por CPF: {ex.Message}");
            }
        }

        public List<Cliente> BuscarPorNome(string nome)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nome))
                    throw new ArgumentException("Nome não pode ser vazio.");

                return _repository.BuscarPorNome(nome);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar clientes por nome: {ex.Message}");
            }
        }

        public void AtualizarCliente(Cliente cliente)
        {
            try
            {
                ValidarCliente(cliente);

                var existente = _repository.BuscarPorId(cliente.Id);
                if (existente == null)
                {
                    throw new Exception("Cliente não encontrado.");
                }

                // Verificar se o CPF já existe em outro cliente
                var clienteComCpf = _repository.BuscarPorCpf(cliente.Cpf);
                if (clienteComCpf != null && clienteComCpf.Id != cliente.Id)
                {
                    throw new Exception("CPF já cadastrado para outro cliente.");
                }

                _repository.Atualizar(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar cliente: {ex.Message}");
            }
        }

        public void DeletarCliente(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                var cliente = _repository.BuscarPorId(id);
                if (cliente == null)
                {
                    throw new Exception("Cliente não encontrado.");
                }

                _repository.Deletar(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar cliente: {ex.Message}");
            }
        }

        public bool ExisteCliente(int id)
        {
            try
            {
                return _repository.BuscarPorId(id) != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar existência do cliente: {ex.Message}");
            }
        }

        public bool ExisteCpf(string cpf)
        {
            try
            {
                return _repository.ExistePorCpf(cpf);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar existência do CPF: {ex.Message}");
            }
        }

        private void ValidarCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "Cliente não pode ser nulo.");

            if (string.IsNullOrWhiteSpace(cliente.Nome))
                throw new ArgumentException("Nome do cliente é obrigatório.");

            if (string.IsNullOrWhiteSpace(cliente.Cpf))
                throw new ArgumentException("CPF do cliente é obrigatório.");

            if (cliente.Nome.Length < 3)
                throw new ArgumentException("Nome deve ter pelo menos 3 caracteres.");

            if (cliente.Cpf.Length < 11)
                throw new ArgumentException("CPF deve ter pelo menos 11 caracteres.");
        }
    }
}
