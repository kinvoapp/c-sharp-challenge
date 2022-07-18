using DesafioKinvo.Domain.Interfaces;
using DesafioKinvo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DesafioKinvo.Data.Repository
{
    public class InvestmentRepository : Repository<Investment>, IInvestmentRepository
    {
        public InvestmentRepository(DataContext db) : base(db)
        {
        }

        public async Task ChangeAmount(Guid id, int amount)
        {
            var investment = await ObterPorId(id);

            investment.ChangeAmount(amount);

            await Atualizar(investment);

        }

        public async Task ChangePrice(Guid id, decimal price)
        {
            var investment = await ObterPorId(id);

            investment.ChangePrice(price);

            await Atualizar(investment);

        }

        public async Task<List<Investment>> GetInvestments(Guid clientId)
        {
            var investments = await Db.Investment.Where(x => x.ClientId == clientId).ToListAsync();

            return investments;
        }

        public async Task RescueInvestment(Guid id, DateTime date)
        {
            var investment = await ObterPorId(id);

            investment.Rescue(date);

            await Atualizar(investment);
        }
    }
}
