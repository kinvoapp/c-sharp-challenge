using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKinvo.Domain.Entities.Validators
{
    public class InvestmentValidator : AbstractValidator<Investment>
    {
        public InvestmentValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                .Length(2, 5).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");
            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.");
            RuleFor(p => p.Amount)
                .NotEqual(0).WithMessage("O campo {PropertyName} não pode ser igual a 0");
            RuleFor(p => p.Price)
                .NotEqual(0).WithMessage("O campo {PropertyName} não pode ser igual a 0");
            RuleFor(p => p.Rate)
                .NotEqual(0).WithMessage("O campo {PropertyName} não pode ser igual a 0");
        }
    }
}
