using Microsoft.AspNetCore.Authorization;
using Back_Atletica.Business;
using Back_Atletica.Models;
using Microsoft.AspNetCore.Mvc;
using Back_Atletica.Utils;
using static Back_Atletica.Utils.ResponseModels.AtleticaResponseModels;
using Back_Atletica.Utils.RequestModels;

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

        /// <summary>
        /// Detalhes de uma atletica
        /// </summary>
        /// <param name="id">Id da atletica desejada</param>
        /// <returns>Todos os dados da atletica</returns>
        /// <response code="200">Objeto criado no banco</response>
        /// <response code="400">Erro na validação dos dados</response>
        [ProducesResponseType(typeof(AtleticaPorId), 200)]
        [Route("api/Atletica/BuscaPorId/{id}")]
        [HttpGet]
        public IActionResult BuscaPorId(int id)
        {
            HttpRes resultado = _AtleticaBusiness.BuscaPorId(id);
            return resultado.HttpResponse();
        }

        [Authorize]
        [Route("api/Atletica/{id}")]
        [HttpPut]
        public IActionResult Atualizar(int id, [FromBody] AtleticaModel valor)
        {
            Atletica atletica = valor.Transform();

            var resultado = _AtleticaBusiness.Atualizar(id, atletica, valor.CursosIds);

            return resultado.HttpResponse();
        }

        [Authorize]
        [Route("api/Atletica/ResetPin/{atleticaId}")]
        [HttpPut]
        public IActionResult ResetPin(int atleticaId)
        {
            HttpRes resultado = _AtleticaBusiness.ResetPin(atleticaId);

            return resultado.HttpResponse();
        }

        [Authorize]
        [Route("api/Atletica/{atleticaId}")]
        [HttpDelete]
        public IActionResult Deletar(int atleticaId)
        {
            var userId = HttpToken.GetUserId(HttpContext);

            if (atleticaId != userId) return new HttpRes(401, "Você nao corresponde a atletica que deseja deletar").HttpResponse();

            var result = _AtleticaBusiness.Deletar(atleticaId);
            return result.HttpResponse();
        }
    }
}
