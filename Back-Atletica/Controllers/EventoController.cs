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
        [Route("api/Eventos/Atletica/{atleticaId}")]
        [HttpGet]
        public IActionResult GetEventosAtletica(int atleticaId)
        {
            var resultado = _EventoBusiness.BuscarTodos(atleticaId);
            return resultado.HttpResponse();
        }

        // GET api/<EventoController>/
        [Route("api/Evento/{eventoId}")]
        [HttpGet]
        public IActionResult GetEvento(int eventoId)
        {
            var resultado = _EventoBusiness.BuscarEvento(eventoId);
            return resultado.HttpResponse();
        }

        // GET api/<EventoController>/
        [Route("api/Evento/Categorias")]
        [HttpGet]
        public IActionResult GetCategoriasEvento()
        {
            var resultado = _EventoBusiness.BuscarCategoriasEvento();
            return resultado.HttpResponse();
        }

        // POST api/<EventoController>
        [Route("api/Evento/{atleticaId}")]
        [HttpPost]
        public IActionResult Post([FromBody] CriarEventoModel evento, int atleticaId)
        {
            Evento e = evento.Transform();
            var resultado = _EventoBusiness.CriarEvento(e, atleticaId);
            return resultado.HttpResponse();
        }

        // PUT api/<EventoController>/5
        [Route("api/Evento/{eventoId}")]
        [HttpPut]
        public IActionResult Put(int id, [FromBody] CriarEventoModel evento, int eventoId)
        {
            Evento e = evento.Transform();
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
