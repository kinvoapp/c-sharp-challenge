using DesafioKinvo.Core.Interfaces;
using DesafioKinvo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKinvo.Domain.Interfaces
{
    public interface IInvestmentService : IService<Investment>
    {
        Task<bool> ChangeAmount(Guid Id, int amount);
        Task<bool> RescueInvestment(Guid Id, DateTime date);
        Task<bool> ChangePrice(Guid Id, decimal price);
    }
}
