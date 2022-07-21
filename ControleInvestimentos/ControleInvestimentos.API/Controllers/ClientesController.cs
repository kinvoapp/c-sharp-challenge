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
    public class ClientesController : ControllerBase
    {

        private readonly IApplicationServiceCliente _applicationServiceCliente;


        public ClientesController(IApplicationServiceCliente applicationServiceCliente)
        {
            this._applicationServiceCliente = applicationServiceCliente;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceCliente.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceCliente.GetById(id));
        }
        [HttpPost]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                if (cliente == null)
                    return NotFound();
                if (cliente.Id > 0)
                    cliente.Id = 0;

                _applicationServiceCliente.Add(cliente);
                return Ok("Cliente Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        [HttpPut]
        public ActionResult Put([FromBody] Cliente cliente)
        {
            try
            {
                if (cliente == null)
                    return NotFound();
                _applicationServiceCliente.Update(cliente);
                return Ok("Cliente Atualizado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpDelete()]
        public ActionResult Delete([FromBody] Cliente cliente)
        {
            try
            {
                if (cliente == null)
                    return NotFound();

                _applicationServiceCliente.Remove(cliente);
                return Ok("Cliente Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
