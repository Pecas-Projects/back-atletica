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
    public class FuncaoController : ControllerBase
    {
        private IFuncaoBusiness _FuncaoBusiness;

        public FuncaoController(IFuncaoBusiness funcaoBusiness)
        {
            _FuncaoBusiness = funcaoBusiness;
        }

        // GET: api/<FuncaoController>
        
        [HttpGet]
        public IActionResult Get()
        {
            return BadRequest();
        }

        // GET api/<FuncaoController>/5
        [Route("api/Funcao/{id}")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var resultado = _FuncaoBusiness.GetById(id);

            return resultado.HttpResponse();
        }

        // POST api/<FuncaoController>
        [Route("api/Funcao")]
        [HttpPost]
        public IActionResult Create([FromBody] Funcao value)
        {
            var resultado = _FuncaoBusiness.Create(value);

            return resultado.HttpResponse();
        }

        // PUT api/<FuncaoController>/5
        [Route("api/Funcao/{id}")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Funcao value)
        {
            var resultado = _FuncaoBusiness.Update(value);

            return resultado.HttpResponse();
        }

        // DELETE api/<FuncaoController>/5
        [Route("api/Funcao/{id}")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _FuncaoBusiness.Delete(id);

            return result.HttpResponse();
        }
    }
}
