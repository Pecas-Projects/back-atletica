using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository.Implementação
{
    public class ProdutoRepositoryImpl : IProdutoRepository
    {
        AtleticaContext _context;

        public ProdutoRepositoryImpl(AtleticaContext contxt)
        {
            _context = contxt;
        }

        public HttpRes Atualizar(int id, Produto produto)
        {
            if (produto == null)
            {
                return new HttpRes(400, "Verifique os dados enviados");
            }
            try
            {
                Produto produtoData = _context.Produtos.SingleOrDefault(a => a.ProdutoId == id);

                if (produtoData == null) return new HttpRes(404, "Produto não encontrado");

                produto.ProdutoId = id;

                if (produto.Imagem != null)
                {
                    _context.Imagens.Add(produto.Imagem);
                    _context.SaveChanges();
                    produto.ImagemId = produto.Imagem.ImagemId;
                }

                _context.Entry(produtoData).CurrentValues.SetValues(produto);
                _context.SaveChanges();

                return new HttpRes(200, produto);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }

        }

        public HttpRes BuscarCategorias()
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscarPorAtletica(int atleticaId)
        {
            var produtos = _context.Produtos
                .Where(p => p.AtleticaId.Equals(atleticaId))
                .Include(p => p.Imagem)
                .ToList();

            return new HttpRes(200, produtos);
        }

        public HttpRes BuscarPorCategoria(int atleticaId, int categoriaId)
        {
            var produtos = _context.Produtos
                .Where(p => p.AtleticaId.Equals(atleticaId) && p.ProdutoCategoriaId.Equals(categoriaId))
                .ToList();

            return new HttpRes(200, produtos);
        }

        public HttpRes BuscarPorId(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return new HttpRes(404, "Não existe nenhum produto com este id");
            }
            return new HttpRes(200, produto);
        }

        public HttpRes BuscarPorNome(int atleticaId, string nome)
        {
            var produtos = _context.Produtos
                .Where(p => p.AtleticaId.Equals(atleticaId) && EF.Functions.Like(p.Nome.ToUpper(), "%" + nome.ToUpper() + "%"))
                .OrderBy(p => EF.Functions.Like(p.Nome.ToUpper(), nome.ToUpper() + "%") ? 1 :
                    EF.Functions.Like(p.Nome.ToUpper(), "%" + nome.ToUpper()) ? 3 : 2)
                .ToList();

            return new HttpRes(200, produtos);
        }

        public HttpRes Criar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new HttpRes(200, produto);
        }

        public HttpRes Deletar(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return new HttpRes(404, "Não existe nenhum produto com este id");
            }
            // Remove a imagem do produto também
            Imagem img = new Imagem { ImagemId = produto.ImagemId };
            _context.Imagens.Attach(img);
            _context.Imagens.Remove(img);

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return new HttpRes(204);
        }

        public bool existeProduto(int id)
        {
            return _context.Produtos.Any(e => e.ProdutoId == id);
        }
    }
}
