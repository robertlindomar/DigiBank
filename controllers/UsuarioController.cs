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
           
            return usuarioService.AutenticarUsuario(email, senha);
        }

        // Novo método para login via UID do cartão NFC
        public Usuario LoginPorUID(string uid)
        {
            if (string.IsNullOrEmpty(uid))
                throw new ArgumentException("O UID não pode ser vazio.", nameof(uid));

            return usuarioService.AutenticarPorUID(uid);
        }

    }
}
