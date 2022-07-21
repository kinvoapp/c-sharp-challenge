using ControleInvestimentos.Domain.Entities;
using System.Collections.Generic;

namespace ControleInvestimentos.Aplication.Interfaces
{
    public interface IApplicationServiceCliente
    {
        void Add(Cliente clienteDto);
        
        void Update(Cliente clienteDto);

        void Remove(Cliente clienteDto);

        IEnumerable<Cliente> GetAll();
        
        Cliente GetById(int Id);
    }
}
