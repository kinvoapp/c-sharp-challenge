using DesafioKinvo.Core.DomainObjects;
using DesafioKinvo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKinvo.Domain.Entities
{
    public class Investment : Entity
    {
        public Investment(
            string name, 
            decimal price, 
            int amount,
            decimal rate, 
            DateTime date
            )
        {
            Name = name;
            Price = price;
            Amount = amount;
            Rate = rate;
            Date = date;
            Type = EInvestmentType.Application;
            UpdateTotal();
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Amount { get; private set; }
        public decimal Total { get; private set; }
        public decimal Rate { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Profit { get; private set; }
        public EInvestmentType Type { get; private set; }
        public Guid ClientId { get; private set; }
        public virtual Client Client { get; private set; }

        public void Rescue(DateTime date)
        {
            Date = date;
            Type = EInvestmentType.Rescue;
        }

        public void ChangeAmount(int amount)
        {
            Amount = amount;
            UpdateTotal();
        }

        public void ChangePrice(decimal price)
        {
            Price = price;
            UpdateTotal();
        }

        public void ChangeProfits(decimal profits)
        {
            Profit = profits;
        }

        public void UpdateProfitsPercentual()
        {
            var profit = (Total - Rate);
            Profit = (profit / Total) * 100;
        }

        public void UpdateTotal()
        {
            Total = (Amount * Price) + Rate;
            UpdateProfitsPercentual();
        }
    }
}
