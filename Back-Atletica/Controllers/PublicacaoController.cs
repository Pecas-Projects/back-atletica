using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_Atletica.Business;
using Back_Atletica.Models;
using Back_Atletica.Utils.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Back_Atletica.Controllers
{
    [ApiController]
    public class PublicacaoController : ControllerBase
    {
        private IPublicacaoBusiness _PublicacaoBusiness;

        public PublicacaoController(IPublicacaoBusiness publicacaoBusiness)
        {
            _PublicacaoBusiness = publicacaoBusiness;
        }

        [Authorize]
        [Route("api/Publicacao")]
        [HttpPost]
        public IActionResult Criar([FromBody] PublicacaoModel value)
        {
            Publicacao publicacao = value.Transform();
            var resultado = _PublicacaoBusiness.Criar(publicacao);
            return resultado.HttpResponse();
        }

        [Route("api/PublicacaoAtletica/{atleticaId}")]
        [HttpGet]
        public IActionResult BuscarPorAtletica(int atleticaId)
        {
            var resultado = _PublicacaoBusiness.BuscarPorAtletica(atleticaId);
            return resultado.HttpResponse();
        }

        //[Route("api/Publicacao/{id}")]
        //[HttpGet]
        //public IActionResult BuscarPorId(int id)
        //{
        //    var resultado = _PublicacaoBusiness.BuscarPorId(id);
        //    return resultado.HttpResponse();
        //}

        [Authorize]
        [Route("api/Publicacao/{id}")]
        [HttpPut]
        public IActionResult Atualizar(int id, [FromBody] PublicacaoModel valor)
        {
            Publicacao publicacao = valor.Transform();
            var resultado = _PublicacaoBusiness.Atualizar(id, publicacao);
            return resultado.HttpResponse();
        }

        [Route("api/Publicacao/{id}")]
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            var result = _PublicacaoBusiness.Deletar(id);
            return result.HttpResponse();
        }
    }
}
