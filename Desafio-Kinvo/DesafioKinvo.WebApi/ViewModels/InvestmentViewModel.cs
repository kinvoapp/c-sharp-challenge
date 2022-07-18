using DesafioKinvo.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace DesafioKinvo.WebApi.ViewModels
{
    public class InvestmentViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Total { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Taxa { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public EInvestmentType Tipo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ClientId { get; set; }
        public ClientViewModel Cliente { get; set; }
    }
}
