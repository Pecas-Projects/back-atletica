using Back_Atletica.Models;
using Back_Atletica.Repository;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business.Implementação
{
    public class ProdutoBusinessImpl : IProdutoBusiness
    {
        private IProdutoRepository _ProdutoRepository;

        public ProdutoBusinessImpl(IProdutoRepository produtoRepository)
        {
            _ProdutoRepository = produtoRepository;
        }

        public HttpRes Criar(Produto produto)
        {
            return _ProdutoRepository.Criar(produto);
        }

        public HttpRes Deletar(int id)
        {
            return _ProdutoRepository.Deletar(id);
        }

        public HttpRes BuscarPorId(int id)
        {
            return _ProdutoRepository.BuscarPorId(id);
        }

        HttpRes IProdutoBusiness.BuscarPorAtletica(int atleticaId)
        {
            return _ProdutoRepository.BuscarPorAtletica(atleticaId);
        }

        HttpRes IProdutoBusiness.BuscarPorNome(int atleticaId, string nome)
        {
            return _ProdutoRepository.BuscarPorNome(atleticaId, nome);
        }

        HttpRes IProdutoBusiness.BuscarPorCategoria(int atleticaId, string categoria)
        {
            return _ProdutoRepository.BuscarPorCategoria(atleticaId, categoria);
        }

        HttpRes IProdutoBusiness.Atualizar(int id, Produto produto)
        {
            return _ProdutoRepository.Atualizar(id, produto);
        }
    }
}
