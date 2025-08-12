using System;

namespace DigiBank.models
{
    public class CartaoNfc
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string Apelido { get; set; }
        public string PinHash { get; set; }
        public int ContaId { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataVinculacao { get; set; }

        // Propriedades de navegação (apenas relacionamentos principais)
        // public virtual Conta Conta { get; set; }
        // public virtual List<PagamentoPos> PagamentosPos { get; set; }

        public CartaoNfc()
        {
            Ativo = true;
            DataVinculacao = DateTime.Now;
        }
    }
}
