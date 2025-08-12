using System;

namespace DigiBank.models
{
    public class PagamentoPos
    {
        public int Id { get; set; }
        public int? TerminalId { get; set; }
        public int? CartaoId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }
        public DateTime DataPagamento { get; set; }
        public string Status { get; set; } // "aprovado", "recusado", "pin_incorreto", "saldo_insuficiente"
        public string Descricao { get; set; }

        // Propriedades de navegação (apenas IDs para evitar referência circular)
        // public virtual TerminalPos Terminal { get; set; }
        // public virtual CartaoNfc Cartao { get; set; }

        public PagamentoPos()
        {
            DataHora = DateTime.Now;
            DataPagamento = DateTime.Now;
        }
    }
}
