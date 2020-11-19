using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_Atletica.Business;
using Back_Atletica.Models;
using Back_Atletica.Utils.RequestModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using static Back_Atletica.Utils.RequestModels.MembroModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back_Atletica.Controllers
{
    [ApiController]
    public class MembroController : ControllerBase
    {
        private IMembroBusiness _MembroBusiness;

        public MembroController(IMembroBusiness membroBusiness)
        {
            _MembroBusiness = membroBusiness;
        }

        
        [Authorize]
        [Route("api/Membro/{atleticaId}/nome={nome}")]
        [HttpGet]
        public IActionResult BuscarPorNome(int atleticaId, string nome) {
            var resultado = _MembroBusiness.BuscarPorNome(atleticaId, nome);

            return resultado.HttpResponse();
        
        }

        // GET: api/<MembroController>
        [Route("api/Membro")]
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var resultado = _MembroBusiness.BuscarTodos();

            return resultado.HttpResponse();
        }

        
        [Route("api/Membro/Atletica/{atleticaId}")]
        [HttpGet]
        public IActionResult BuscarTodos(int atleticaId)
        {
            var resultado = _MembroBusiness.BuscarTodos(atleticaId);

            return resultado.HttpResponse();
        }

        
        [Authorize]
        [Route("api/Membro/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var resultado = _MembroBusiness.BuscarPorId(id);

            return resultado.HttpResponse();
        }

        
        [Route("api/Membro")]
        [HttpPost]
        public IActionResult Criar([FromBody] Membro membro)
        {
            var resultado = _MembroBusiness.Criar(membro);

            return resultado.HttpResponse();
        }

        [Authorize]
        [Route("api/Membro/{id}")]
        [HttpPut]
        public IActionResult Atualizar(int id, [FromBody] AtualizarMembro value)
        {
            Membro membro = value.Transform();

            var resultado = _MembroBusiness.Atualizar(id, membro);

            return resultado.HttpResponse();
        }

        [Authorize]
        [Route("api/Membro/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var resultado = _MembroBusiness.Deletar(id);

            return resultado.HttpResponse();
        }

    }
}
