using ControleInvestimentos.Aplication.Interfaces;
using ControleInvestimentos.Domain.Entities;
using ControleInvestimentos.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleInvestimentos.Aplication
{
    public class ApplicationServiceCliente : IApplicationServiceCliente
    {
        private readonly IServiceCliente _serviceCliente;
        public ApplicationServiceCliente(IServiceCliente serviceCliente)
        {
            _serviceCliente = serviceCliente;
        }
        public void Add(Cliente cliente)
        {
            _serviceCliente.Add(cliente);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _serviceCliente.GetAll();
        }

        public Cliente GetById(int Id)
        {
            return _serviceCliente.GetById(Id);
        }

        public void Remove(Cliente cliente)
        {
            _serviceCliente.Remove(cliente);
        }

        public void Update(Cliente cliente)
        {
            _serviceCliente.Update(cliente);
        }
    }
}
