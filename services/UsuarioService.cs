using DigiBank.models;
using DigiBank.repositories;
using System;
using System.Collections.Generic;

namespace DigiBank.services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _repository;
        private readonly ClienteService _clienteService;

        public UsuarioService()
        {
            _repository = new UsuarioRepository();
            _clienteService = new ClienteService();
        }

        public int CriarUsuario(Usuario novoUsuario)
        {
            try
            {
                ValidarUsuario(novoUsuario);

                // Verificar se o cliente existe
                if (!_clienteService.ExisteCliente(novoUsuario.ClienteId))
                {
                    throw new Exception("Cliente não encontrado.");
                }

                // Verificar se o login já existe
                if (_repository.ExisteLogin(novoUsuario.Login))
                {
                    throw new Exception("Login já existe.");
                }

                return _repository.Criar(novoUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar usuário: {ex.Message}");
            }
        }

        public List<Usuario> BuscarTodos()
        {
            try
            {
                return _repository.BuscarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar usuários: {ex.Message}");
            }
        }

        public Usuario BuscarPorId(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                return _repository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar usuário por ID: {ex.Message}");
            }
        }

        public Usuario BuscarPorLogin(string login)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(login))
                    throw new ArgumentException("Login não pode ser vazio.");

                return _repository.BuscarPorLogin(login);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar usuário por login: {ex.Message}");
            }
        }

        public Usuario BuscarPorClienteId(int clienteId)
        {
            try
            {
                if (clienteId <= 0)
                    throw new ArgumentException("ID do cliente deve ser maior que zero.");

                return _repository.BuscarPorClienteId(clienteId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar usuário por cliente: {ex.Message}");
            }
        }

        public List<Usuario> BuscarPorTipo(string tipo)
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
                throw new Exception($"Erro ao buscar usuários por tipo: {ex.Message}");
            }
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            try
            {
                ValidarUsuario(usuario);

                var existente = _repository.BuscarPorId(usuario.Id);
                if (existente == null)
                {
                    throw new Exception("Usuário não encontrado.");
                }

                // Verificar se o login já existe em outro usuário
                var usuarioComLogin = _repository.BuscarPorLogin(usuario.Login);
                if (usuarioComLogin != null && usuarioComLogin.Id != usuario.Id)
                {
                    throw new Exception("Login já existe para outro usuário.");
                }

                _repository.Atualizar(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar usuário: {ex.Message}");
            }
        }

        public void AtualizarSenha(int id, string novaSenha)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                if (string.IsNullOrWhiteSpace(novaSenha))
                    throw new ArgumentException("Nova senha não pode ser vazia.");

                if (novaSenha.Length < 6)
                    throw new ArgumentException("Senha deve ter pelo menos 6 caracteres.");

                var usuario = _repository.BuscarPorId(id);
                if (usuario == null)
                {
                    throw new Exception("Usuário não encontrado.");
                }

                _repository.AtualizarSenha(id, novaSenha);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar senha: {ex.Message}");
            }
        }

        public void DeletarUsuario(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                var usuario = _repository.BuscarPorId(id);
                if (usuario == null)
                {
                    throw new Exception("Usuário não encontrado.");
                }

                _repository.Deletar(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar usuário: {ex.Message}");
            }
        }

        public void DesativarUsuario(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID deve ser maior que zero.");

                var usuario = _repository.BuscarPorId(id);
                if (usuario == null)
                {
                    throw new Exception("Usuário não encontrado.");
                }

                _repository.Desativar(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao desativar usuário: {ex.Message}");
            }
        }

        public bool ExisteUsuario(int id)
        {
            try
            {
                return _repository.BuscarPorId(id) != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar existência do usuário: {ex.Message}");
            }
        }

        public bool ExisteLogin(string login)
        {
            try
            {
                return _repository.ExisteLogin(login);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar existência do login: {ex.Message}");
            }
        }

        public bool ValidarCredenciais(string login, string senha)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(login))
                    throw new ArgumentException("Login não pode ser vazio.");

                if (string.IsNullOrWhiteSpace(senha))
                    throw new ArgumentException("Senha não pode ser vazia.");

                return _repository.ValidarCredenciais(login, senha);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao validar credenciais: {ex.Message}");
            }
        }

        public Usuario FazerLogin(string login, string senha)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(login))
                    throw new ArgumentException("Login não pode ser vazio.");

                if (string.IsNullOrWhiteSpace(senha))
                    throw new ArgumentException("Senha não pode ser vazia.");

                var usuario = _repository.BuscarPorLogin(login);
                if (usuario == null)
                {
                    throw new Exception("Usuário não encontrado.");
                }

                if (!usuario.Ativo)
                {
                    throw new Exception("Usuário está inativo.");
                }

                if (!_repository.ValidarCredenciais(login, senha))
                {
                    throw new Exception("Senha incorreta.");
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao fazer login: {ex.Message}");
            }
        }

        private void ValidarUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario), "Usuário não pode ser nulo.");

            if (string.IsNullOrWhiteSpace(usuario.Login))
                throw new ArgumentException("Login é obrigatório.");

            if (string.IsNullOrWhiteSpace(usuario.Senha))
                throw new ArgumentException("Senha é obrigatória.");

            if (usuario.ClienteId <= 0)
                throw new ArgumentException("ID do cliente deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(usuario.Tipo))
                throw new ArgumentException("Tipo é obrigatório.");

            if (usuario.Login.Length < 3)
                throw new ArgumentException("Login deve ter pelo menos 3 caracteres.");

            if (usuario.Senha.Length < 6)
                throw new ArgumentException("Senha deve ter pelo menos 6 caracteres.");

            if (!usuario.Tipo.Equals("cliente", StringComparison.OrdinalIgnoreCase) &&
                !usuario.Tipo.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Tipo deve ser 'cliente' ou 'admin'.");
            }
        }
    }
}
