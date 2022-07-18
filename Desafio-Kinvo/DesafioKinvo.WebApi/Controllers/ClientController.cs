using AutoMapper;
using DesafioKinvo.Core.Interfaces;
using DesafioKinvo.Domain.Entities;
using DesafioKinvo.Domain.Interfaces;
using DesafioKinvo.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioKinvo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : MainController
    {
        private readonly IClientService _service;
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public ClientController(
            INotificador notificador,
            IClientService service,
            IClientRepository repository,
            IMapper mapper) : base(notificador)
        {
            _service = service;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientViewModel>>> GetAllClients()
        {
            var clients = _mapper.Map<ClientViewModel>(await _repository.ObterTodos());
            
            if(clients == null) return NotFound("Nenhum cliente cadastrado!");

            return Ok(clients);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ClientViewModel>> GetClientById([FromRoute]Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Id inválido");

            var client = _mapper.Map<ClientViewModel>(await _repository.ObterPorId(id));

            if (client == null) return NotFound("Nenhum cliente encontrado");

            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult> AddClient([FromBody] ClientViewModel client)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponse(client);

                await _service.Add(_mapper.Map<Client>(client));

                return CustomResponse(client);

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> UpdateClient([FromBody] ClientViewModel client)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponse(client);

                await _service.Update(_mapper.Map<Client>(client));

                return CustomResponse(client);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteClient([FromRoute] Guid Id)
        {
            if (Id == Guid.Empty) return BadRequest("Id inválido!");

            var client = await _repository.ObterPorId(Id);

            if (client == null) return NotFound("Nenhum cliente encontrado!");

            await _service.Delete(Id);

            return CustomResponse(client);

        }
    }
}
