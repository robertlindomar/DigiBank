using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Tipo { get; set; }


        public Usuario()
        {
        }

        public Usuario(int id, int clienteId, string login, string senha, bool ativo, DateTime dataCriacao, string tipo)
        {
            Id = id;
            ClienteId = clienteId;
            Login = login;
            Senha = senha;
            Ativo = ativo;
            DataCriacao = dataCriacao;
            Tipo = tipo;
        }
    }
}
