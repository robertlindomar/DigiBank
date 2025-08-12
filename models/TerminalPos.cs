using System;
using System.Collections.Generic;

namespace DigiBank.models
{
    public class TerminalPos
    {
        public int Id { get; set; }
        public string NomeLoja { get; set; }
        public string Localizacao { get; set; }
        public string Uid { get; set; }
        public int ContaId { get; set; }

        // Propriedades de navegação
        public virtual Conta Conta { get; set; }

        public TerminalPos()
        {
            // Construtor sem inicialização de lista para evitar referência circular
        }
    }
}
