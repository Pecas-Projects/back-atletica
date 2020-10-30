using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_Atletica.Business;
using Back_Atletica.Models;
using Microsoft.AspNetCore.Mvc;
using static Back_Atletica.Utils.RequestModels.EventoModel;

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
        [Route("api/Evento/{atleticaId}")]
        [HttpPost]
        public IActionResult Post([FromBody] CriarEventoModel evento, int atleticaId)
        {
            Evento e = evento.Transform();
            EventoCategoria categoria = new EventoCategoria();
            categoria.Nome = evento.NomeCategoria;
            e.EventoCategoria = categoria;
            var resultado = _EventoBusiness.CriarEvento(e, atleticaId);
            return resultado.HttpResponse();
        }

        // PUT api/<EventoController>/5
        [Route("api/Evento/{eventoId}")]
        [HttpPut]
        public IActionResult Put(int id, [FromBody] CriarEventoModel evento, int eventoId)
        {
            Evento e = evento.Transform();
            EventoCategoria categoria = new EventoCategoria();
            categoria.Nome = evento.NomeCategoria;
            e.EventoCategoria = categoria;
            var resultado = _EventoBusiness.AtualizarEvento(eventoId, e);
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
