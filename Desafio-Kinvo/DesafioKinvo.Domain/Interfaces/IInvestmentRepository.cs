using DesafioKinvo.Core.Interfaces;
using DesafioKinvo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKinvo.Domain.Interfaces
{
    public interface IInvestmentRepository : IRepository<Investment>
    {
        Task<List<Investment>> GetInvestments(Guid clientId);
        Task RescueInvestment(Guid id, DateTime date);
        Task ChangeAmount(Guid id, int amount);
        Task ChangePrice(Guid id, decimal price);

    }
}
