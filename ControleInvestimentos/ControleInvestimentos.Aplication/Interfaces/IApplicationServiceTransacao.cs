using ControleInvestimentos.Domain.Core.Interfaces.DTO;
using ControleInvestimentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleInvestimentos.Aplication.Interfaces
{
    public interface IApplicationServiceTransacao
    {
        void Add(Transacao transacao);

        void Update(Transacao transacao);

        void Remove(Transacao transacao);

        IEnumerable<Transacao> GetAll();

        Transacao GetById(int Id);
        IEnumerable<TransacaoByAcaoDto> GetGroupByAcao();
        IEnumerable<Transacao> GetByCliente(int id);
    }
}
