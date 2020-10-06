using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_Atletica.Business;
using Back_Atletica.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_Produto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoBusiness _ProdutoBusiness;

        public ProdutoController(IProdutoBusiness produtoBusiness)
        {
            _ProdutoBusiness = produtoBusiness;
        }

        [Route("api/Produto")]
        [HttpPost]
        public IActionResult Criar([FromBody] Produto value)
        {
            var resultado = _ProdutoBusiness.Criar(value);
            return resultado.HttpResponse();
        }

        [Route("api/Produto/{atleticaId}")]
        [HttpGet("{atleticaId}")]
        public IActionResult BuscarPorAtletica(int atleticaId)
        {
            var resultado = _ProdutoBusiness.BuscarPorAtletica(atleticaId);
            return resultado.HttpResponse();
        }

        [Route("api/Produto/{id}")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var resultado = _ProdutoBusiness.BuscarPorId(id);
            return resultado.HttpResponse();
        }

        [Route("api/Produto/{atleticaId}/{nome}")]
        [HttpGet("{atleticaId}/{nome}")]
        public IActionResult BuscarPorNome(int atleticaId, string nome)
        {
            var resultado = _ProdutoBusiness.BuscarPorNome(atleticaId, nome);
            return resultado.HttpResponse();
        }

        [Route("api/Produto/{atleticaId}/{categoria}")]
        [HttpGet("{atleticaId}/{categoria}")]
        public IActionResult BuscarPorCategoria(int atleticaId, string categoria)
        {
            var resultado = _ProdutoBusiness.BuscarPorCategoria(atleticaId, categoria);
            return resultado.HttpResponse();
        }

        [Route("api/Produto/{id}")]
        [HttpPut]
        public IActionResult Atualizar(int id, [FromBody] Produto valor)
        {
            var resultado = _ProdutoBusiness.Atualizar(id, valor);
            return resultado.HttpResponse();
        }

        [Route("api/Produto/{id}")]
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            var result = _ProdutoBusiness.Deletar(id);
            return result.HttpResponse();
        }
    }
}
