using ControleInvestimentos.Domain.Core.Interfaces.Repositorys;
using ControleInvestimentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleInvestimentos.Infrastructure.Data.Repositotrys
{
    public class RepositoryCliente:RepositoryBase<Cliente>, IRepositoryCliente
    {
        public PgSqlContext _sqlContext;
        public RepositoryCliente(PgSqlContext sqlContext):base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
