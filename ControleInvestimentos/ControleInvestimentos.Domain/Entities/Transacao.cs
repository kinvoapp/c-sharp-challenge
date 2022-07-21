using System;
using System.Collections.Generic;
using System.Text;

namespace ControleInvestimentos.Domain.Entities
{
    public class Transacao: Base
    {
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public string Acao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Taxa { get; set; }
        public ETipo Tipo { get; set; }
        public DateTime Data { get; set; }
    }

    public enum ETipo {Aplicacao,Retirada }
}
