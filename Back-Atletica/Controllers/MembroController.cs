using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_Atletica.Business;
using Back_Atletica.Models;
using Microsoft.AspNetCore.Mvc;

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

        
        [Route("api/Membro/{cargo}")]
        [HttpGet]
        public IActionResult BuscarPorCargo(string cargo)
        {
            var resultado = _MembroBusiness.BuscarPorCargo(cargo);

            return resultado.HttpResponse();
        }

        [Route("api/Membro/{departamento}")]
        [HttpGet]
        public IActionResult BuscarPorDepartamento(string departamento)
        {
            var resultado = _MembroBusiness.BuscarPorDepartamento(departamento);

            return resultado.HttpResponse();
        }

        [Route("api/Membro/{nome}")]
        [HttpGet]
        public IActionResult BuscarPorNome(string nome) {
            var resultado = _MembroBusiness.BuscarPorNome(nome);

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

        // GET api/<MembroController>/5
        [Route("api/Membro/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var resultado = _MembroBusiness.BuscarPorId(id);

            return resultado.HttpResponse();
        }

        // POST api/<MembroController>
        [Route("api/Membro")]
        [HttpPost]
        public IActionResult Criar([FromBody] Membro membro)
        {
            var resultado = _MembroBusiness.Criar(membro);

            return resultado.HttpResponse();
        }

        // PUT api/<MembroController>/5
        [Route("api/Membro/{id}")]
        [HttpPut]
        public IActionResult Atualizar(int id, [FromBody] Membro membro)
        {
            var resultado = _MembroBusiness.Atualizar(id, membro);

            return resultado.HttpResponse();
        }

        // DELETE api/<MembroController>/5
        [Route("api/Membro/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var resultado = _MembroBusiness.Deletar(id);

            return resultado.HttpResponse();
        }

    }
}
