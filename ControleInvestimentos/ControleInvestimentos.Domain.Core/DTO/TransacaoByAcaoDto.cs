using System;
using System.Collections.Generic;
using System.Text;

namespace ControleInvestimentos.Domain.Core.Interfaces.DTO
{
    public class TransacaoByAcaoDto
    {
        public string Acao { get; set; }
        public decimal PrecoMedio { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
    }
}
