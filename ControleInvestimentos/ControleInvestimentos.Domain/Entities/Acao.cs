using System;
using System.Collections.Generic;
using System.Text;

namespace ControleInvestimentos.Domain.Entities
{
    public class Acao: Base
    {
        public string Codigo { get; set; }
        public decimal Preco_Medio { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor_Total { get; set; }
    }
}
