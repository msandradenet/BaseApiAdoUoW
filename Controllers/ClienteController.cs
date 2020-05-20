using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BaseApiAdoUow.CORE.Models;
using BaseApiAdoUow.CORE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BaseApiAdoUow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        IConfiguration _config;
        private readonly IClienteService _clienteService;

        public ClienteController(IConfiguration config, IClienteService clienteService)
        {
            _config = config;
            _clienteService = clienteService;
        }

        [HttpGet]
        public ActionResult<Cliente> Get()
        {
            var result = _clienteService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Cliente> Get(int id)
        {
            var result = _clienteService.Get(id);

            return Ok(result);
        }

        [HttpPost]
        public ContentResult Post([FromBody] Cliente value)
        {
            var result = _clienteService.Create(value);

            if (result)
                return new ContentResult() { StatusCode = (int)HttpStatusCode.OK, Content = "Incluido com sucesso!" };
            else
                return new ContentResult() { StatusCode = (int)HttpStatusCode.BadRequest, Content = "Erro ao incluir!" };
        }

        [HttpPut("{id}")]
        public ContentResult Put(int id, [FromBody] Cliente value)
        {
            var result = _clienteService.Update(value);

            if (result)
                return new ContentResult() { StatusCode = (int)HttpStatusCode.OK, Content = "Atualizado com sucesso!" };
            else
                return new ContentResult() { StatusCode = (int)HttpStatusCode.BadRequest, Content = "Erro ao atualizar!" };
        }

        [HttpDelete("{id}")]
        public ContentResult Delete(int id)
        {
            var result = _clienteService.Delete(id);

            if (result)
                return new ContentResult() { StatusCode = (int)HttpStatusCode.OK, Content = "Deletado com sucesso!" };
            else
                return new ContentResult() { StatusCode = (int)HttpStatusCode.BadRequest, Content = "Erro ao deletar!" };
        }
    }
}
