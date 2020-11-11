using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_Atletica.Business.Implementação;
using Back_Atletica.Models;
using Microsoft.AspNetCore.Mvc;
using static Back_Atletica.Utils.RequestModels.SolicitacaoJogoModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back_Atletica.Controllers
{
    [ApiController]
    public class SolicitacaoJogoController : ControllerBase
    {
        private ISolicitacaoJogoBusiness _SolicitacaoJogoBusiness;

        public SolicitacaoJogoController(ISolicitacaoJogoBusiness solicitacaoJogoBusiness)
        {
            _SolicitacaoJogoBusiness = solicitacaoJogoBusiness;
        }

        // GET: api/<SolicitacaoJogoController>
        [Route("api/SolicitacaoJogo/{atleticaId}")]
        [HttpGet]
        public IActionResult GetSolicitacoesJogo(int atleticaId)
        {
            var resultado = _SolicitacaoJogoBusiness.BuscarTodas(atleticaId);
            return resultado.HttpResponse();
        }

        // POST api/<SolicitacaoJogoController>
        [Route("api/SolicitacaoJogo/{atleticaId}")]
        [HttpPost]
        public IActionResult Post([FromBody] CriarSolicitacaoJogoModel solicitacaoJogo, int atleticaId)
        {
            SolicitacaoJogo s = solicitacaoJogo.Transform();
            s.AtleticaAdversariaId = atleticaId;
            var resultado = _SolicitacaoJogoBusiness.CriarSolicitacaoJogo(s, atleticaId);
            return resultado.HttpResponse();
        }


        // DELETE api/<SolicitacaoJogoController>/5
        [Route("api/SolicitacaoJogo/{solicitacaoJogoId}/aprovado")]
        [HttpDelete]
        public IActionResult DeleteAprovado(int solicitacaoJogoId)
        {
            var resultado = _SolicitacaoJogoBusiness.DeletarSolicitacaoJogoAprovado(solicitacaoJogoId);
            return resultado.HttpResponse();
        }

        // DELETE api/<SolicitacaoJogoController>/5
        [Route("api/SolicitacaoJogo/{solicitacaoJogoId}/reprovado")]
        [HttpDelete]
        public IActionResult DeleteReprovado(int solicitacaoJogoId)
        {
            var resultado = _SolicitacaoJogoBusiness.DeletarSolicitacaoJogo(solicitacaoJogoId);
            return resultado.HttpResponse();
        }
    }
}
