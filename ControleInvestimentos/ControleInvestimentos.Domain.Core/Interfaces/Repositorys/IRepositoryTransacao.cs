using ControleInvestimentos.Domain.Core.Interfaces.DTO;
using ControleInvestimentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleInvestimentos.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryTransacao: IRepositoryBase<Transacao>
    {
        IEnumerable<TransacaoByAcaoDto> GetGroupByAcao();
        IEnumerable<Transacao> GetByCliente(int id);
    }
}
