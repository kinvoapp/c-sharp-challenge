using ControleInvestimentos.Domain.Core.Interfaces.DTO;
using ControleInvestimentos.Domain.Core.Interfaces.Repositorys;
using ControleInvestimentos.Domain.Core.Interfaces.Services;
using ControleInvestimentos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleInvestimentos.Domain.Services
{
    public class ServiceTransacao : ServiceBase<Transacao>, IServiceTransacao
    {
        private readonly IRepositoryTransacao _repositoryTransacao;
        private readonly IRepositoryCliente _repositoryCliente;
        public ServiceTransacao(IRepositoryTransacao repositoryTransacao,IRepositoryCliente repositoryCliente) : base(repositoryTransacao)
        {
            _repositoryTransacao = repositoryTransacao;
            _repositoryCliente = repositoryCliente;
        }

        public IEnumerable<TransacaoByAcaoDto> GetGruopByAcao()
        {
            return _repositoryTransacao.GetGroupByAcao();
        }

        public IEnumerable<Transacao> GetByCliente(int id)
        {
            var transacoes = _repositoryTransacao.GetByCliente(id);
            var cliente = _repositoryCliente.GetById(id);
            FillClienteInTransacao(transacoes, cliente);
            return transacoes;

        }

        public void FillClienteInTransacao(IEnumerable<Transacao> transacoes, Cliente cliente)
        {
            foreach (var transacao in transacoes)
            {
                transacao.Cliente = cliente;
            }
        }
    }
}
