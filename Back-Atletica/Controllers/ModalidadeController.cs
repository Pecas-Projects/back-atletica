﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_Atletica.Business;
using Back_Atletica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using static Back_Atletica.Utils.RequestModels.ModalidadeModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back_Atletica.Controllers
{
    [ApiController]
    public class ModalidadeController : ControllerBase
    {

        private IModalidadeBusiness _ModalidadeBusiness;

        public ModalidadeController(IModalidadeBusiness modalidadeBusiness)
        {
            _ModalidadeBusiness = modalidadeBusiness;
        }


        // GET api/<ModalidadeController>/5
        [Route("api/Modalidade")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var resultado = _ModalidadeBusiness.BuscarPorTodos();
            return resultado.HttpResponse();
        }

        // GET api/<ModalidadeController>/5
        [Route("api/Modalidade/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var resultado = _ModalidadeBusiness.BuscarPorId(id);
            return resultado.HttpResponse();
        }

        [Route("api/{atleticaId}/Modalidade")]
        [HttpGet]
        public IActionResult GetAll(int atleticaId)
        {
            var resultado = _ModalidadeBusiness.BuscarTodasNaAtletica(atleticaId);

            return resultado.HttpResponse();
        }

        // POST api/<ModalidadeController>
        [Route("api/Modalidade")]
        [HttpPost]
        public IActionResult Create([FromBody] Modalidade modalidade)
        {
            var resultado = _ModalidadeBusiness.Criar(modalidade);

            return resultado.HttpResponse();
        }

        [Route("api/{atleticaId}/Modalidade")]
        [HttpPost]
        public IActionResult CriarAtleticaModalidade([FromBody] ModalidadeAtletica modalidade, int atleticaId)
        {
            AtleticaModalidade atleticaModalidade = modalidade.Transform(atleticaId);

            var resultado = _ModalidadeBusiness.CriarAtleticaModalidade(atleticaModalidade);

            return resultado.HttpResponse();
        }

        // DELETE api/<ModalidadeController>/5
        [Route("api/Modalidade/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var resultado = _ModalidadeBusiness.Deletar(id);

            return resultado.HttpResponse();
        }

        [Route("api/AtleticaModalidade/{atleticaModalidadeId}")]
        [HttpDelete]
        public IActionResult ExcluiModalidadeAtletica(int atleticaModalidadeId)
        {
            var resultado = _ModalidadeBusiness.ExcluiModalidadeAtletica(atleticaModalidadeId);

            return resultado.HttpResponse();
        }
    }
}
