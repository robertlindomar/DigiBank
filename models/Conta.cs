using System;
using System.Collections.Generic;

namespace DigiBank.models
{
    public class Conta
    {
        public int Id { get; set; }
        public string NumeroConta { get; set; }
        public string Tipo { get; set; }
        public decimal Saldo { get; set; }
        public bool Ativa { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataAbertura { get; set; }

        // Propriedades de navegação (apenas relacionamentos principais)
        public virtual Cliente Cliente { get; set; }

        public Conta()
        {
            Ativa = true;
            DataAbertura = DateTime.Now;
            Saldo = 0.00m;
        }
    }
}
