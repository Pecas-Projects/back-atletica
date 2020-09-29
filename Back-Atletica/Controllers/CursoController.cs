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
    public class CursoController : ControllerBase
    {
        private ICursoBusiness _CursoBusiness;

        public CursoController(ICursoBusiness cursoBusiness)
        {
            _CursoBusiness = cursoBusiness;
        }

        [Route("api/Curso")]
        public IActionResult Create([FromBody] Curso value)
        {
            var resultado = _CursoBusiness.Create(value);

            return resultado.HttpResponse();
        }

        [Route("api/Cursos")]
        // GET: api/<CursoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CursoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CursoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CursoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CursoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
