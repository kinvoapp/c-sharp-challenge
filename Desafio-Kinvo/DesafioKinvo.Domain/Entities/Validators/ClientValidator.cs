using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKinvo.Domain.Entities.Validators
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode ser vazio.")
                .Length(5, 50).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");

        }
    }
}
