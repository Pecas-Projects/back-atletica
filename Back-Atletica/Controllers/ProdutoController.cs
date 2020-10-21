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

        [Route("api/AtleticaProduto/{atleticaId}")]
        [HttpGet]
        public IActionResult BuscarPorAtletica(int atleticaId)
        {
            var resultado = _ProdutoBusiness.BuscarPorAtletica(atleticaId);
            return resultado.HttpResponse();
        }

        [Route("api/Produto/{id}")]
        [HttpGet]
        public IActionResult BuscarPorId(int id)
        {
            var resultado = _ProdutoBusiness.BuscarPorId(id);
            return resultado.HttpResponse();
        }

        [Route("api/Produto/{atleticaId}/{nome}")]
        [HttpGet]
        public IActionResult BuscarPorNome(int atleticaId, string nome)
        {
            var resultado = _ProdutoBusiness.BuscarPorNome(atleticaId, nome);
            return resultado.HttpResponse();
        }

        [Route("api/ProdutoCategoria/{atleticaId}/{categoriaId}")]
        [HttpGet]
        public IActionResult BuscarPorCategoria(int atleticaId, int categoriaId)
        {
            var resultado = _ProdutoBusiness.BuscarPorCategoria(atleticaId, categoriaId);
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
