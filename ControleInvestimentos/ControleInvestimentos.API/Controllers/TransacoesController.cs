using ControleInvestimentos.Aplication.Interfaces;
using ControleInvestimentos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleInvestimentos.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransacoesController : Controller
    {
        private readonly IApplicationServiceTransacao _applicationServiceTransacao;


        public TransacoesController(IApplicationServiceTransacao applicationServiceTransacao)
        {
            this._applicationServiceTransacao = applicationServiceTransacao;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceTransacao.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceTransacao.GetById(id));
        }
        [HttpPost]
        public ActionResult Post([FromBody] Transacao transacao)
        {
            try
            {
                if (transacao == null)
                    return NotFound();
                if (transacao.Id > 0)
                    transacao.Id = 0;

                _applicationServiceTransacao.Add(transacao);
                return Ok("Transação Cadastrada com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("/GetGroupByAcao")]
        public ActionResult<IEnumerable<string>> GetGroupByAcao()
        {
            return Ok(_applicationServiceTransacao.GetGroupByAcao());
        }

        [HttpGet("/GetByCliente/{id}")]
        public ActionResult<IEnumerable<string>> GetByCliente(int id)
        {
            return Ok(_applicationServiceTransacao.GetByCliente(id));
        }


    }
}
