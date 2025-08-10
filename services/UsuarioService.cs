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


        public Usuario AutenticarUsuario(string email, string senha)
        {
            return usuarioRepository.Login(email, senha);
        }
    }
}
