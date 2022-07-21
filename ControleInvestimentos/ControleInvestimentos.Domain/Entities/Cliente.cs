using System;
using System.Collections.Generic;
using System.Text;

namespace ControleInvestimentos.Domain.Entities
{
    public class Cliente: Base
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}
