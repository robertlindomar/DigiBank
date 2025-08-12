using System;

namespace DigiBank.models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataCriacao { get; set; }

        // Propriedades de navegação (apenas relacionamentos principais)
        // public virtual List<Conta> Contas { get; set; }
        // public virtual Usuario Usuario { get; set; }

        public Cliente()
        {
            DataCriacao = DateTime.Now;
        }
    }
}
