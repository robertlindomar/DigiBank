using System;

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
        public string Tipo { get; set; } // "cliente" ou "admin"

        // Propriedades de navegação (apenas relacionamentos principais)
        // public virtual Cliente Cliente { get; set; }

        public Usuario()
        {
            Ativo = true;
            DataCriacao = DateTime.Now;
            Tipo = "cliente";
        }
    }
}
