using ControleInvestimentos.Domain.Core.Interfaces.Repositorys;
using ControleInvestimentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleInvestimentos.Infrastructure.Data.Repositotrys
{
    public class RepositoryTransacao : RepositoryBase<Transacao>, IRepositoryTransacao
    {
        public SqlContext _sqlContext;
        public RepositoryTransacao(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
        public void GetByAcao(int id)
        {
            throw new NotImplementedException();
        }

        public void GetByCliente(int id)
        {
            throw new NotImplementedException();
        }
    }
}
