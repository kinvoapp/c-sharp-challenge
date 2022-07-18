using DesafioKinvo.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKinvo.Domain.Entities
{
    public class Client : Entity
    {
        public string Name { get; private set; }

        private readonly List<Investment> _investments;

        public IReadOnlyCollection<Investment> Investments => _investments;

        public Client(string name)
        {
            Name = name;
            _investments = new List<Investment>();
        }

        public void AddInvestment(Investment investment)
        {
            _investments.Add(investment);
        }

        public void RemoveInvestment(Investment investment)
        {
            _investments.Remove(investment);
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return;
            }

            Name = name;
        }
    }
}
