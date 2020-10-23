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
    public class TimeController : ControllerBase
    {
        private ITimeBusiness _TimeBusiness;

        public TimeController(ITimeBusiness timeBusiness)
        {
            _TimeBusiness = timeBusiness;
        }

        // GET: api/<TimeController>
        [Route("api/{atleticaId}/Times")]
        [HttpGet]
        public IActionResult GetTimesAtletica(int atleticaId)
        {
           var resultado = _TimeBusiness.BuscarTodos(atleticaId);

            return resultado.HttpResponse();
        }

        // GET api/<TimeController>/5
        [Route("api/Time/{id}")]
        [HttpGet]
        public IActionResult GetTime(int id)
        {
            var resultado = _TimeBusiness.BuscarPorId(id);

            return resultado.HttpResponse();
        }

        // POST api/<TimeController>
        [Route("api/Time")]
        [HttpPost]
        public IActionResult Post([FromBody] TimeEscalado time)
        {
            var resultado = _TimeBusiness.CriarTime(time);

            return resultado.HttpResponse();
        }

        // PUT api/<TimeController>/5
        [Route("api/Time/{id}")]
        [HttpPut]
        public IActionResult Put(int id, [FromBody] TimeEscalado value)
        {
            var resultado = _TimeBusiness.Atualizar(id, value);

            return resultado.HttpResponse();
        }

        // DELETE api/<TimeController>/5
        [Route("api/Time/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            var resultado = _TimeBusiness.Deletar(id);

            return resultado.HttpResponse();
        }
    }
}
