using ControleInvestimentos.Domain.Core.Interfaces.DTO;
using ControleInvestimentos.Domain.Core.Interfaces.Repositorys;
using ControleInvestimentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleInvestimentos.Infrastructure.Data.Repositotrys
{
    public class RepositoryTransacao : RepositoryBase<Transacao>, IRepositoryTransacao
    {
        public PgSqlContext _sqlContext;
        public RepositoryTransacao(PgSqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }
        public IEnumerable<TransacaoByAcaoDto> GetGroupByAcao()
        {
            var query = from t in _sqlContext.Transacoes
                        group t by t.Acao into a
                        select new TransacaoByAcaoDto
                        {
                            Acao = a.Key,
                            PrecoMedio = (a.Sum(x => (x.Tipo == ETipo.Retirada ? 0 : x.Subtotal)) + a.Sum(x => (x.Tipo == ETipo.Retirada ? 0 : x.Taxa))) / a.Sum(x => (x.Tipo == ETipo.Retirada ? 0 : x.Quantidade)),
                            Quantidade = a.Sum(x => (x.Tipo == ETipo.Retirada ? (x.Quantidade * -1) : x.Quantidade)),
                            Total = (a.Sum(x => (x.Tipo == ETipo.Retirada ? (x.Quantidade * -1) : x.Quantidade)) > 0 ? a.Sum(x => x.Subtotal) : 0)
                        };
            return query.ToList();
        }

        public IEnumerable<Transacao> GetByCliente(int id)
        {
            return _sqlContext.Set<Transacao>().Where(x => x.ClienteId == id).ToList();
        }
    }
}
