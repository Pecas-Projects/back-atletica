using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_Atletica.Business;
using Back_Atletica.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Back_Atletica.Utils.RequestModels.SolicitacaoAtletaModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back_Atletica.Controllers
{
    [ApiController]
    public class SolicitacaoAtletaController : ControllerBase
    {
        private ISolicitacaoAtletaBusiness _SolicitacaoAtletaBusiness;

        public SolicitacaoAtletaController(ISolicitacaoAtletaBusiness solicitacaoAtletaBusiness)
        {
            _SolicitacaoAtletaBusiness = solicitacaoAtletaBusiness;
        }

        // GET: api/<SolicitacaoAtletaController>
        [Authorize]
        [Route("api/SolicitacaoAtleta/{atleticaId}")]
        [HttpGet]
        public IActionResult GetSolicitacoesAtleta(int atleticaId)
        {
            var resultado = _SolicitacaoAtletaBusiness.BuscarTodas(atleticaId);
            return resultado.HttpResponse();
        }

        // POST api/<SolicitacaoAtletaController>
 
        [Route("api/SolicitacaoAtleta/{atleticaId}")]
        [HttpPost]
        public IActionResult Post([FromBody] CriarSolicitacaoAtletaModel solicitacaoAtleta, int atleticaId)
        {
            SolicitacaoAtleta s = solicitacaoAtleta.Transform();
            s.AtleticaId = atleticaId;
            var resultado = _SolicitacaoAtletaBusiness.CriarSolicitacaoAtletas(s, solicitacaoAtleta.ModalidadesId);
            return resultado.HttpResponse();
        }

        // DELETE api/<SolicitacaoAtletaController>/5
        [Authorize]
        [Route("api/SolicitacaoAtleta/{solicitacaoAtletaId}/aprovado")]
        [HttpDelete]
        public IActionResult DeleteAprovado(int solicitacaoAtletaId)
        {
            var resultado = _SolicitacaoAtletaBusiness.DeletarSolicitacaoAtletaAprovado(solicitacaoAtletaId);
            return resultado.HttpResponse();
        }

        // DELETE api/<SolicitacaoAtletaController>/5
        [Authorize]
        [Route("api/SolicitacaoAtleta/{solicitacaoAtletaId}/reprovado")]
        [HttpDelete]
        public IActionResult DeleteReprovado(int solicitacaoAtletaId)
        {
            var resultado = _SolicitacaoAtletaBusiness.DeletarSolicitacaoAtleta(solicitacaoAtletaId);
            return resultado.HttpResponse();
        }
    }
}
