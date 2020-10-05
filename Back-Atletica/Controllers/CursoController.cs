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

        // POST api/<CursoController>
        [Route("api/Curso")]
        [HttpPost]
        public IActionResult Create([FromBody] Curso value)
        {
            var resultado = _CursoBusiness.Criar(value);

            return resultado.HttpResponse();
        }

        [Route("api/Cursos")]
        // GET: api/<CursoController>
        [HttpGet]
        public IActionResult Get()
        {
            var resultado = _CursoBusiness.BuscarTodos();

            return resultado.HttpResponse();
        }

        // GET api/<CursoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var resultado = _CursoBusiness.BuscarPorId(id);

            return resultado.HttpResponse();
        }

    }
}
