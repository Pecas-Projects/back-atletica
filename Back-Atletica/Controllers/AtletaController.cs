using Microsoft.AspNetCore.Authorization;
using Back_Atletica.Business;
using Back_Atletica.Models;
using Microsoft.AspNetCore.Mvc;
using Back_Atletica.Utils;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back_Atletica.Controllers
{
    
    [ApiController]
    public class AtletaController : ControllerBase
    {
        private IAtletaBusiness _AtletaBusiness;

        public AtletaController(IAtletaBusiness atletaBusiness)
        {
            _AtletaBusiness = atletaBusiness;
        }

        [Route("api/AtletaAtletica/{atleticaID}")]
        [HttpGet]
        public IActionResult BuscarTodos (int atleticaID)
        {
            var resultado = _AtletaBusiness.BuscarTodos(atleticaID);
            return resultado.HttpResponse();
            
        }

        [Route("api/Atleta/{atletaID}")]
        [HttpGet]
        public IActionResult BuscarPorID(int atletaID)
        {
            var resultado = _AtletaBusiness.BuscaPorID(atletaID);
            return resultado.HttpResponse();
        }

        [Route("api/AtletaModalidade/{modalidadeID}")]
        [HttpGet]
        public IActionResult BuscarPorModalidade(int modalidadeID)
        {
            var resultado = _AtletaBusiness.BuscaPorModalidade(modalidadeID);
            return resultado.HttpResponse();
        }

        [Route("api/AtletaTime/{timeID}")]
        [HttpGet]
        public IActionResult BuscarPorTime(int timeID)
        {
            var resultado = _AtletaBusiness.BuscaPorTime(timeID);
            return resultado.HttpResponse();
        }

        [Route("api/AtletaAtivo/{atleticaID}")]
        [HttpGet]
        public IActionResult BuscarAtivo(int atleticaID)
        {
            var resultado = _AtletaBusiness.BuscaAtivos(atleticaID);
            return resultado.HttpResponse();
        }

        [Route("api/Atleta")]
        [HttpPost]
        public IActionResult CriarAtleta([FromBody] Atleta value)
        {
            var resultado = _AtletaBusiness.CriarAtleta(value);
            return resultado.HttpResponse();
        }

     
        [Route("api/Atleta/{atletaID}")]
        [HttpPut]
        public IActionResult Atualizar(int atletaID, [FromBody] Atleta value)
        {
            var resultado = _AtletaBusiness.Atualizar(atletaID, value);
            return resultado.HttpResponse();
        }

        [Route("api/Atleta/{atletaID}")]
        [HttpDelete]
        public IActionResult Delete(int atletaID)
        {
            var resultado = _AtletaBusiness.Deletar(atletaID);
            return resultado.HttpResponse();
        }
    }
}
