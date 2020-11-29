using Microsoft.AspNetCore.Authorization;
using Back_Atletica.Business;
using Back_Atletica.Models;
using Microsoft.AspNetCore.Mvc;
using static Back_Atletica.Utils.RequestModels.AtletaAtleticaModalidadeTimeEscaladoModel;
using System.Collections.Generic;


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

        //[Route("api/AtletaAtletica/{atleticaID}")]
        //[HttpGet]
        //public IActionResult BuscarTodos (int atleticaID)
        //{
        //    var resultado = _AtletaBusiness.BuscarTodos(atleticaID);
        //    return resultado.HttpResponse();

        //}

        //[Route("api/Atleta/{atletaID}")]
        //[HttpGet]
        //public IActionResult BuscarPorID(int atletaID)
        //{
        //    var resultado = _AtletaBusiness.BuscaPorID(atletaID);
        //    return resultado.HttpResponse();
        //}

        [Authorize]
        [Route("api/AtletaModalidade/{atleticaModalidadeId}")]
        [HttpGet]
        public IActionResult BuscarPorModalidade(int atleticaModalidadeId)
        {
            var resultado = _AtletaBusiness.BuscaPorModalidade(atleticaModalidadeId);
            return resultado.HttpResponse();
        }

        //[Route("api/AtletaJogo/{jogoID}")]
        //[HttpGet]
        //public IActionResult BuscarPorJogo(int JogoID)
        //{
        //    var resultado = _AtletaBusiness.BuscaPorJogo(JogoID);
        //    return resultado.HttpResponse();
        //}

        //[Route("api/AtletaAtivo/{atleticaID}")]
        //[HttpGet]
        //public IActionResult BuscarAtivo(int atleticaID)
        //{
        //    var resultado = _AtletaBusiness.BuscaAtivos(atleticaID);
        //    return resultado.HttpResponse();
        //}

        //[Route("api/Atleta")]
        //[HttpPost]
        //public IActionResult CriarAtleta([FromBody] Atleta value)
        //{
        //    var resultado = _AtletaBusiness.CriarAtleta(value);
        //    return resultado.HttpResponse();
        //}

        ///// <summary>
        ///// Atualizar Atleta
        ///// </summary>
        ///// <param name="atletaId">ID do atleta que será atualizado</param>
        ///// <returns>Atleta atualizado</returns>
        ///// <response code="200">Objeto criado no banco</response>
        ///// <response code="400">Erro na validação dos dados</response>
        //[ProducesResponseType(typeof(AtualizarAtletaModel), 200)]
        //[Route("api/Atleta/{atletaID}")]
        //[HttpPut]
        //public IActionResult Atualizar(int atletaID, [FromBody] AtualizarAtletaModel value)
        //{
        //    Atleta atleta = value.Transform();

        //    var resultado = _AtletaBusiness.Atualizar(atletaID, atleta);
        //    return resultado.HttpResponse();
        //}

        //[Route("api/Atleta/{atletaID}")]
        //[HttpDelete]
        //public IActionResult Delete(int atletaID)
        //{
        //    var resultado = _AtletaBusiness.Deletar(atletaID);
        //    return resultado.HttpResponse();
        //}

        [Authorize]
        [Route("api/AtletaTime/{timeId}")]
        [HttpPost]
        public IActionResult AdicionarAtletaTime(int timeId, [FromBody] List<CriarAtletaAtleticaModalidadeTimeEscaladoModel> criarAtletaAtleticaModalidadeTimeEscaladoModels)
        {
            List<AtletaAtleticaModalidadeTimeEscalado> atletasTime = new List<AtletaAtleticaModalidadeTimeEscalado>();

            foreach (CriarAtletaAtleticaModalidadeTimeEscaladoModel atletaTimeModel in criarAtletaAtleticaModalidadeTimeEscaladoModels)
            {
                AtletaAtleticaModalidadeTimeEscalado atletaAtleticaModalidadeTimeEscalado = atletaTimeModel.Transform();
                atletasTime.Add(atletaAtleticaModalidadeTimeEscalado);
            }
            
            var resultado = _AtletaBusiness.AdicionarAtletaTime(timeId, atletasTime);
            return resultado.HttpResponse();
        }

        [Authorize]
        [Route("api/AtletaTime/{atletaAtleticaModalidadeTimeEscaladoId}")]
        [HttpPut]
        public IActionResult AtualizarAtletaTime(int atletaAtleticaModalidadeTimeEscaladoId, [FromBody] AtualizarAtletaAtleticaModalidadeTimeEscaladoModel atualizarAtletaAtleticaModalidadeTimeEscaladoModel)
        {
            AtletaAtleticaModalidadeTimeEscalado atletaAtleticaModalidadeTimeEscalado = atualizarAtletaAtleticaModalidadeTimeEscaladoModel.Transform();
            atletaAtleticaModalidadeTimeEscalado.AtletaAtleticaModalidadeTimeEscaladoId = atletaAtleticaModalidadeTimeEscaladoId;

            var resultado = _AtletaBusiness.AtualizarAtletaTime(atletaAtleticaModalidadeTimeEscalado);
            return resultado.HttpResponse();
        }

        [Authorize]
        [Route("api/AtletaTime/{atletaAtleticaModalidadeTimeEscaladoId}")]
        [HttpDelete]
        public IActionResult RemoverAtletaTime(int atletaAtleticaModalidadeTimeEscaladoId)
        {
            var resultado = _AtletaBusiness.RemoverAtletaTime(atletaAtleticaModalidadeTimeEscaladoId);
            return resultado.HttpResponse();
        }

        [Authorize]
        [Route("api/AtletaModalidade/{atletaId}/{atleticaModalidadeId}")]
        [HttpPost]
        public IActionResult AdicionarAtletaModalidade(int atletaId, int atleticaModalidadeId)
        {
            var resultado = _AtletaBusiness.AdicionarAtletaModalidade(atletaId, atleticaModalidadeId);
            return resultado.HttpResponse();
        }

        [Authorize]
        [Route("api/AtletaModalidade/{atletaAtleticaModalidadeId}")]
        [HttpDelete]
        public IActionResult RemoverAtletaModalidade(int atletaAtleticaModalidadeId)
        {
            var resultado = _AtletaBusiness.RemoverAtletaModalidade(atletaAtleticaModalidadeId);
            return resultado.HttpResponse();
        }

        [Authorize]
        [Route("api/AtletaForaModalidade/{atleticaId}/{modalidadeId}")]
        [HttpGet]
        public IActionResult BuscarForaModalidade(int atleticaId, int modalidadeId)
        {
            var resultado = _AtletaBusiness.BuscarForaModalidade(atleticaId, modalidadeId);
            return resultado.HttpResponse();
        }
    }
}
