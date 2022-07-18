using System.ComponentModel.DataAnnotations;

namespace DesafioKinvo.WebApi.ViewModels
{
    public class ClientViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        public List<InvestmentViewModel> Investimentos { get; set; }
    }
}
