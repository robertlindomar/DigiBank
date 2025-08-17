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

                // Verificar se o login já existe
                if (_repository.ExisteLogin(novoCliente.Login))
                {
                    throw new Exception("Login já cadastrado.");
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

        public Cliente BuscarPorLogin(string login)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(login))
                    throw new ArgumentException("Login não pode ser vazio.");

                return _repository.BuscarPorLogin(login);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar cliente por login: {ex.Message}");
            }
        }

        public List<Cliente> BuscarPorTipo(string tipo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tipo))
                    throw new ArgumentException("Tipo não pode ser vazio.");

                if (!tipo.Equals("cliente", StringComparison.OrdinalIgnoreCase) &&
                    !tipo.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Tipo deve ser 'cliente' ou 'admin'.");
                }

                return _repository.BuscarPorTipo(tipo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar clientes por tipo: {ex.Message}");
            }
        }

        public void AtivarCliente(int id)
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

                cliente.Ativo = true;
                _repository.Atualizar(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao ativar cliente: {ex.Message}");
            }
        }

        public void DesativarCliente(int id)
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

                cliente.Ativo = false;
                _repository.Atualizar(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao desativar cliente: {ex.Message}");
            }
        }

        public Cliente FazerLogin(string login, string senha)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(login))
                    throw new ArgumentException("Login não pode ser vazio.");

                if (string.IsNullOrWhiteSpace(senha))
                    throw new ArgumentException("Senha não pode ser vazia.");

                var cliente = _repository.BuscarPorLogin(login);
                if (cliente == null)
                {
                    throw new Exception("Login ou senha incorretos.");
                }

                if (!cliente.Ativo)
                {
                    throw new Exception("Conta desativada. Entre em contato com o suporte.");
                }

                // Aqui você implementaria a verificação de senha hash
                // Por enquanto, vamos fazer uma comparação simples
                if (cliente.Senha != senha)
                {
                    throw new Exception("Login ou senha incorretos.");
                }

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao fazer login: {ex.Message}");
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

            if (string.IsNullOrWhiteSpace(cliente.Login))
                throw new ArgumentException("Login do cliente é obrigatório.");

            if (string.IsNullOrWhiteSpace(cliente.Senha))
                throw new ArgumentException("Senha do cliente é obrigatória.");

            if (cliente.Nome.Length < 3)
                throw new ArgumentException("Nome deve ter pelo menos 3 caracteres.");

            if (cliente.Cpf.Length < 11)
                throw new ArgumentException("CPF deve ter pelo menos 11 caracteres.");

            if (cliente.Login.Length < 3)
                throw new ArgumentException("Login deve ter pelo menos 3 caracteres.");

            if (cliente.Senha.Length < 6)
                throw new ArgumentException("Senha deve ter pelo menos 6 caracteres.");

            if (string.IsNullOrWhiteSpace(cliente.Tipo))
                throw new ArgumentException("Tipo do cliente é obrigatório.");

            if (!cliente.Tipo.Equals("cliente", StringComparison.OrdinalIgnoreCase) &&
                !cliente.Tipo.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Tipo deve ser 'cliente' ou 'admin'.");
            }
        }
    }
}
