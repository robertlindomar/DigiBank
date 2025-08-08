using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiBank.models
{
    public class Conta
    {
        public int Id { get; set; }
        public string NumeroConta { get; set; }
        public string Tipo { get; set; } // "corrente" or "poupanca"
        public decimal Saldo { get; set; }
        public bool Ativa { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataAbertura { get; set; }
    }
}
