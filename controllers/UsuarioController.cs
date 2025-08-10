using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiBank.models;
using DigiBank.services;


namespace DigiBank.controllers
{
    public class UsuarioController
    {
        private readonly UsuarioService usuarioService;

        public UsuarioController()
        {
            usuarioService = new UsuarioService();
        }

        public int CriarUsuario(Usuario novoUsuario)
        {
            return usuarioService.CriarUsuario(novoUsuario);
        }

        public Usuario Login(string email, string senha)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("O e-mail não pode ser vazio.", nameof(email));
            }

            if (string.IsNullOrEmpty(senha))
            {
                throw new ArgumentException("A senha não pode ser vazia.", nameof(senha));
            }

            return usuarioService.AutenticarUsuario(email, senha);
        }

    }
}
