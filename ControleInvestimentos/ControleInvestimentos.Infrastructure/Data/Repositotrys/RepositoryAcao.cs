using ControleInvestimentos.Domain.Core.Interfaces.Repositorys;
using ControleInvestimentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleInvestimentos.Infrastructure.Data.Repositotrys
{
    public class RepositoryAcao:RepositoryBase<Acao>,IRepositoryAcao
    {
        public SqlContext _sqlContext;
        public RepositoryAcao(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
    }
}
