using Microsoft.AspNetCore.Authorization;
using Back_Atletica.Business;
using Back_Atletica.Models;
using Microsoft.AspNetCore.Mvc;
using Back_Atletica.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back_Atletica.Controllers
{
    
    [ApiController]
    public class AtleticaController : ControllerBase
    {
        private IAtleticaBusiness _AtleticaBusiness;

        public AtleticaController(IAtleticaBusiness atleticaBusiness)
        {
            _AtleticaBusiness = atleticaBusiness;
        }

        [Route("api/AtleticaFaculdade/{faculdadeId}")]
        [HttpGet]
        public IActionResult BuscarPorInstituicao(int faculdadeId)
        {
            var resultado = _AtleticaBusiness.BuscaPorInstituicao(faculdadeId);
            return resultado.HttpResponse();
        }

        [Route("api/AtleticaNome/{nome}")]
        [HttpGet]
        public IActionResult BuscarPorNome(string nome)
        {
            var resultado = _AtleticaBusiness.BuscaPorNome(nome);
            return resultado.HttpResponse();
        }

        [Route("api/Atletica")]
        [HttpGet]
        public IActionResult Get()
        {
            var resultado = _AtleticaBusiness.BuscarTodos();
            return resultado.HttpResponse();
        }

        [Route("api/Atletica/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var resultado = _AtleticaBusiness.BuscaPorId(id);
            return resultado.HttpResponse();
        }

        //[Route("api/Atletica")]
        //[HttpPost]
        //public IActionResult Criar([FromBody] Atletica value)
        //{
        //    var resultado = _AtleticaBusiness.Criar(value);
        //    return resultado.HttpResponse();
        //}

        [Authorize]
        [Route("api/Atletica/{id}")]
        [HttpPut]
        public IActionResult Atualizar(int id, [FromBody] Atletica valor)
        {
            var userId = HttpToken.GetUserId(HttpContext);

            var resultado = _AtleticaBusiness.Atualizar(id, valor);
            return resultado.HttpResponse();
        }

        [Route("api/Atletica/{id}")]
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            var result = _AtleticaBusiness.Deletar(id);
            return result.HttpResponse();
        }
    }
}
