using System;

namespace DigiBank.models
{
    public class Transacao
    {
        public int Id { get; set; }
        public string Tipo { get; set; } // "deposito", "saque", "transferencia"
        public decimal Valor { get; set; }
        public DateTime DataTransacao { get; set; }
        public int? ContaOrigemId { get; set; }
        public int? ContaDestinoId { get; set; }
        public string Descricao { get; set; }

        // Propriedades de navegação (apenas relacionamentos principais)
        // public virtual Conta ContaOrigem { get; set; }
        // public virtual Conta ContaDestino { get; set; }

        public Transacao()
        {
            DataTransacao = DateTime.Now;
        }
    }
}
