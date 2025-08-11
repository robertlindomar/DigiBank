using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiBank.repositories;
using DigiBank.models;

namespace DigiBank.services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository usuarioRepository;

        public UsuarioService()
        {
            usuarioRepository = new UsuarioRepository();
        }

        public int CriarUsuario(Usuario usuario)
        {
            return usuarioRepository.Criar(usuario);
        }

        // Autenticação tradicional (login + senha)
        public Usuario AutenticarUsuario(string login, string senha)
        {
            return usuarioRepository.Login(login, senha);
        }

        // Autenticação via UID do cartão NFC
        public Usuario AutenticarPorUID(string uid)
        {
            return usuarioRepository.LoginPorUID(uid);
        }
    }
}
