using ControleInvestimentos.Domain.Core.Interfaces.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleInvestimentos.Infrastructure.Data.Repositotrys
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public SqlContext _sqlContext;
        public RepositoryBase(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }
        public void Add(T obj)
        {
            try
            {
                _sqlContext.Set<T>().Add(obj);
                _sqlContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao persistir registro na base de dados -> Insert -> \n"+e.Message);
            }    
        }

        public IEnumerable<T> GetAll()
        {
            return _sqlContext.Set<T>().ToList();
        }

        public T GetById(int Id)
        {
            return _sqlContext.Set<T>().Find(Id);
        }

        public void Remove(T obj)
        {
            try
            {
                _sqlContext.Set<T>().Remove(obj);
                _sqlContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao persistir registro na base de dados -> Remove -> \n" + e.Message);
            }
        }

        public void Update(T obj)
        {
            try
            {
                _sqlContext.Set<T>().Update(obj);
                _sqlContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao persistir registro na base de dados -> Update -> \n" + e.Message);
            }
        }
    }
}
