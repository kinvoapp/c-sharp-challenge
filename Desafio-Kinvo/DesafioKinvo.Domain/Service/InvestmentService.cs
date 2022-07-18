using DesafioKinvo.Core.Interfaces;
using DesafioKinvo.Domain.Entities;
using DesafioKinvo.Domain.Entities.Validators;
using DesafioKinvo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKinvo.Domain.Service
{
    public class InvestmentService : BaseService, IInvestmentService
    {
        private readonly IInvestmentRepository _repository;
        public InvestmentService(
            INotificador notificador,
            IInvestmentRepository repository) : base(notificador)
        {
            _repository = repository;
        }

        public async Task<bool> Add(Investment objeto)
        {
            if (!ExecutarValidacao(new InvestmentValidator(), objeto)) return false;

            await _repository.Adicionar(objeto);
            return true;
        }

        public async Task<bool> ChangeAmount(Guid Id, int amount)
        {
            if (amount <= 0)
            {
                Notificar("Quantidade não pode ser menor ou igual a zero");
                return false;
            }

            await _repository.ChangeAmount(Id, amount);

            return true;
        }

        public async Task<bool> ChangePrice(Guid Id, decimal price)
        {
            if (price <= 0)
            {
                Notificar("Preço não pode ser menor ou igual a 0");
                return false;
            }

            await _repository.ChangePrice(Id, price);

            return true;
        }

        public async Task<bool> Delete(Guid Id)
        {
            if(Id == Guid.Empty) return false;

            await _repository.Remover(Id);

            return true;
        }

        public async Task<bool> RescueInvestment(Guid Id, DateTime date)
        {
            if(date > DateTime.Now)
            {
                Notificar("Data inválida");
                return false;
            }

            await _repository.RescueInvestment(Id, date);

            return true;
        }

        public async Task<bool> Update(Investment objeto)
        {
            if (!ExecutarValidacao(new InvestmentValidator(), objeto)) return false;

            await _repository.Atualizar(objeto);
            return true;
        }
    }
}
