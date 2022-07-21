using ControleInvestimentos.Domain.Core.Interfaces.Repositorys;
using ControleInvestimentos.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleInvestimentos.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repository;
        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }
        public void Add(T obj)
        {
            _repository.Add(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(T obj)
        {
            _repository.Remove(obj);
        }

        public void Update(T obj)
        {
            _repository.Update(obj);
        }
    }
}
