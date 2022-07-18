using DesafioKinvo.Core.DomainObjects;
using DesafioKinvo.Core.Interfaces;
using DesafioKinvo.Domain.Entities;
using DesafioKinvo.Domain.Entities.Validators;
using DesafioKinvo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioKinvo.Domain.Service
{
    public class ClienteService : BaseService, IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IInvestmentRepository _investmentRepository;
        public ClienteService(
            INotificador notificador,
            IClientRepository clientRepository,
            IInvestmentRepository investmentRepository) : base(notificador)
        {
            _clientRepository = clientRepository;
            _investmentRepository = investmentRepository;
        }

        public async Task<bool> Add(Client objeto)
        {
            if (!ExecutarValidacao(new ClientValidator(), objeto)) return false;

            if(_clientRepository.Buscar(x => x.Name == objeto.Name).Result.Any())
            {
                Notificar("Já existe um cliente com esse nome!");
                return false;
            }
            await _clientRepository.Adicionar(objeto);
            return true;
        }

        public async Task<bool> Delete(Guid Id)
        {
            if(_investmentRepository.GetInvestments(Id).Result.Any())
            {
                Notificar("O cliente possui investimentos");
                return false;
            }

            await _clientRepository.Remover(Id);
            return true;
        }

        public async Task<bool> Update(Client objeto)
        {
            if (!ExecutarValidacao(new ClientValidator(), objeto)) return false;

            if (_clientRepository.Buscar(x => x.Name == objeto.Name).Result.Any())
            {
                Notificar("Já existe um cliente com esse nome!");
                return false;
            }
            await _clientRepository.Atualizar(objeto);
            return true;
        }
    }
}
