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
    public class EventoController : ControllerBase
    {
        private IEventoBusiness _EventoBusiness;

        public EventoController(IEventoBusiness eventoBusiness)
        {
            _EventoBusiness = eventoBusiness;
        }

        // GET: api/<EventoController>
        [Route("api/Eventos/{atleticaId}")]
        [HttpGet]
        public IActionResult GetEventosAtletica(int atleticaId)
        {
            var resultado = _EventoBusiness.BuscarTodos(atleticaId);
            return resultado.HttpResponse();
        }

        // GET api/<EventoController>/5
        [Route("api/Eventos/{atleticaId}/{nomeCategoria}")]
        [HttpGet]
        public IActionResult GetEventosAtleticaCategoria(int atleticaId, string nomeCategoria)
        {
            var resultado = _EventoBusiness.BuscarPorCategoria(atleticaId, nomeCategoria);
            return resultado.HttpResponse();
        }

        // POST api/<EventoController>
        [Route("api/Evento")]
        [HttpPost]
        public IActionResult Post([FromBody] Evento evento)
        {
            var resultado = _EventoBusiness.CriarEvento(evento);
            return resultado.HttpResponse();
        }

        // PUT api/<EventoController>/5
        [Route("api/Evento/{eventoId}")]
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Evento evento, int eventoId)
        {
            var resultado = _EventoBusiness.AtualizarEvento(eventoId, evento);
            return resultado.HttpResponse();
        }

        // DELETE api/<EventoController>/5
        [Route("api/Evento/{eventoId}")]
        [HttpDelete]
        public IActionResult Delete(int eventoId)
        {
            var resultado = _EventoBusiness.DeletarEvento(eventoId);
            return resultado.HttpResponse();
        }
    }
}
