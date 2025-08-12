using DigiBank.models;
using DigiBank.services;
using System;
using System.Collections.Generic;

namespace DigiBank.controllers
{
    public class UsuarioController
    {
        private readonly UsuarioService _service;

        public UsuarioController()
        {
            _service = new UsuarioService();
        }

        public int Criar(Usuario usuario)
        {
            try
            {
                return _service.CriarUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao criar usuário: {ex.Message}");
            }
        }

        public List<Usuario> BuscarTodos()
        {
            try
            {
                return _service.BuscarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar usuários: {ex.Message}");
            }
        }

        public Usuario BuscarPorId(int id)
        {
            try
            {
                return _service.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar usuário por ID: {ex.Message}");
            }
        }

        public Usuario BuscarPorLogin(string login)
        {
            try
            {
                return _service.BuscarPorLogin(login);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar usuário por login: {ex.Message}");
            }
        }

        public Usuario BuscarPorClienteId(int clienteId)
        {
            try
            {
                return _service.BuscarPorClienteId(clienteId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar usuário por cliente: {ex.Message}");
            }
        }

        public List<Usuario> BuscarPorTipo(string tipo)
        {
            try
            {
                return _service.BuscarPorTipo(tipo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao buscar usuários por tipo: {ex.Message}");
            }
        }

        public void Atualizar(Usuario usuario)
        {
            try
            {
                _service.AtualizarUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao atualizar usuário: {ex.Message}");
            }
        }

        public void AtualizarSenha(int id, string novaSenha)
        {
            try
            {
                _service.AtualizarSenha(id, novaSenha);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao atualizar senha: {ex.Message}");
            }
        }

        public void Deletar(int id)
        {
            try
            {
                _service.DeletarUsuario(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao deletar usuário: {ex.Message}");
            }
        }

        public void Desativar(int id)
        {
            try
            {
                _service.DesativarUsuario(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao desativar usuário: {ex.Message}");
            }
        }

        public bool Existe(int id)
        {
            try
            {
                return _service.ExisteUsuario(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao verificar existência do usuário: {ex.Message}");
            }
        }

        public bool ExisteLogin(string login)
        {
            try
            {
                return _service.ExisteLogin(login);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao verificar existência do login: {ex.Message}");
            }
        }

        public bool ValidarCredenciais(string login, string senha)
        {
            try
            {
                return _service.ValidarCredenciais(login, senha);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao validar credenciais: {ex.Message}");
            }
        }

        public Usuario FazerLogin(string login, string senha)
        {
            try
            {
                return _service.FazerLogin(login, senha);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no controller ao fazer login: {ex.Message}");
            }
        }
    }
}
