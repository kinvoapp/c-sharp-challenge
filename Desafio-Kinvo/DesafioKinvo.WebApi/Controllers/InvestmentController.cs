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
    public class InvestmentController : MainController
    {
        private readonly IInvestmentService _service;
        private readonly IInvestmentRepository _repository;
        private readonly IMapper _mapper;

        public InvestmentController(
            INotificador notificador,
            IInvestmentService service,
            IInvestmentRepository repository,
            IMapper mapper) : base(notificador)
        {
            _repository = repository;
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("{clientId:guid}")]
        public async Task<ActionResult<List<InvestmentViewModel>>> ObterInvestimentos([FromRoute]Guid clientId)
        {
            if (clientId == Guid.Empty) return BadRequest("Id inválido");

            var investments = _mapper.Map<List<InvestmentViewModel>>(await _repository.GetInvestments(clientId));

            if (investments == null) return NotFound("Nenhum investimento encontrado");

            return CustomResponse(investments);

        }

        [HttpPost]
        public async Task<ActionResult> CadastrarInvestimento([FromBody] InvestmentViewModel investment)
        {
            if (!ModelState.IsValid) return CustomResponse(investment);

            await _service.Add(_mapper.Map<Investment>(investment));

            return CustomResponse(investment);
        }

        [HttpPut("alterar-quantidade/{id:guid}/{quantidade:int}")]
        public async Task<ActionResult> AlterarQuantidade([FromRoute] Guid id, [FromRoute] int quantidade)
        {
            try
            {
                if (id == Guid.Empty) return BadRequest("Id inválido");

                await _service.ChangeAmount(id, quantidade);

                return Ok();

            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("alterar-preco/{id:guid}/{preco:decimal}")]
        public async Task<ActionResult> AlterarPreco([FromRoute] Guid id, [FromRoute] decimal preco)
        {
            try
            {
                if (id == Guid.Empty) return BadRequest("Id inválido");

                await _service.ChangePrice(id, preco);

                return Ok();
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("regatar-investimento/{id:guid}/{data:dateTime}")]
        public async Task<ActionResult> AlterarPreco([FromRoute] Guid id, [FromRoute] DateTime data)
        {
            try
            {
                if (id == Guid.Empty) return BadRequest("Id inválido");

                await _service.RescueInvestment(id, data);

                return Ok();

            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> ApagarInvestimento([FromRoute] Guid id)
        {
            if (id == Guid.Empty) return BadRequest("Id inválido");

            await _service.Delete(id);

            return Ok();
        }

    }
}
