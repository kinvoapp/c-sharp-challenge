using ControleInvestimentos.Domain.Core.Interfaces.DTO;
using ControleInvestimentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleInvestimentos.Domain.Core.Interfaces.Services
{
    public interface IServiceTransacao:IServiceBase<Transacao>
    {
        IEnumerable<TransacaoByAcaoDto> GetGruopByAcao();
        IEnumerable<Transacao> GetByCliente(int id);
        void FillClienteInTransacao(IEnumerable<Transacao> transacoes, Cliente cliente);
    }
}
