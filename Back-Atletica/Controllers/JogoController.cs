using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_Atletica.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Back_Atletica.Utils;
using Back_Atletica.Utils.ResponseModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back_Atletica.Controllers
{
    [ApiController]
    public class JogoController : ControllerBase
    {
        private IJogoBusiness _JogoBusiness;

        public JogoController(IJogoBusiness jogoBusiness)
        {
            _JogoBusiness = jogoBusiness;
        }

        [Route("api/Jogos/{atleticaId}")]
        [HttpGet]
        public IActionResult BuscarPorAtletica(int atleticaId)
        {
            var resultado = _JogoBusiness.BuscarPorAtletica(atleticaId);
            return resultado.HttpResponse();
        }

        [ProducesResponseType(typeof(JogoResponseModels), 200)]
        [Authorize]
        [Route("api/JogosModalidade/{atleticaId}/{modalidadeId}")]
        [HttpGet]
        public IActionResult BuscarPorModalidade(int atleticaId, int modalidadeId)
        {
            var resultado = _JogoBusiness.BuscarPorModalidade(atleticaId, modalidadeId);
            return resultado.HttpResponse();
        }

        [Route("api/CategoriasJogos")]
        [HttpGet]
        public IActionResult BuscarCategorias()
        {
            var resultado = _JogoBusiness.BuscarCategorias();
            return resultado.HttpResponse();
        }

        [Route("api/Jogo/{id}")]
        [HttpGet]
        public IActionResult BuscarPorId(int id)
        {
            var resultado = _JogoBusiness.BuscarPorId(id);
            return resultado.HttpResponse();
        }

        [Authorize]
        [Route("api/Jogo/{id}")]
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            var resultado = _JogoBusiness.Deletar(id);
            return resultado.HttpResponse();
        }
    }
}
