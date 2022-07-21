using ControleInvestimentos.Aplication.Interfaces;
using ControleInvestimentos.Domain.Core.Interfaces.DTO;
using ControleInvestimentos.Domain.Core.Interfaces.Services;
using ControleInvestimentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleInvestimentos.Aplication
{
    public class ApplicationServiceTransacao : IApplicationServiceTransacao
    {
        private readonly IServiceTransacao _serviceTransacao;
        public ApplicationServiceTransacao(IServiceTransacao serviceTransacao)
        {
            _serviceTransacao = serviceTransacao;
        }
        public void Add(Transacao transacao)
        {
            _serviceTransacao.Add(transacao);
        }

        public IEnumerable<Transacao> GetAll()
        {
            return _serviceTransacao.GetAll();
        }

        public IEnumerable<Transacao> GetByCliente(int id)
        {
            return _serviceTransacao.GetByCliente(id);
        }

        public Transacao GetById(int id)
        {
            return _serviceTransacao.GetById(id);
        }

        public IEnumerable<TransacaoByAcaoDto> GetGroupByAcao()
        {
            return _serviceTransacao.GetGruopByAcao();
        }

        public void Remove(Transacao transacao)
        {
            _serviceTransacao.Remove(transacao);
        }

        public void Update(Transacao transacao)
        {
            _serviceTransacao.Update(transacao);
        }
    }
}
