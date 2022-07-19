using ControleInvestimentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleInvestimentos.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryTransacao: IRepositoryBase<Transacao>
    {
        void GetByAcao(int id);
        void GetByCliente(int id);
    }
}
