﻿using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Back_Atletica.Utils.ResponseModels.ProdutoResponseModel;

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
                Produto produtoData = _context.Produtos.SingleOrDefault(a => a.ProdutoId == id && a.AtleticaId == produto.AtleticaId);

                if (produtoData == null) return new HttpRes(404, "Produto não encontrado");

                produto.ProdutoId = id;

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
            List<ProdutoCategoria> categorias = _context.ProdutoCategorias.ToList();
            return new HttpRes(200, categorias);
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
                .Include(p => p.Imagem)
                .ToList();

            return new HttpRes(200, produtos);
        }

        public HttpRes BuscarPorId(int id)
        {
            var produto = _context.Produtos
                .Include(p => p.Imagem)
                .SingleOrDefault(p => p.ProdutoId == id);

            if (produto == null)
            {
                return new HttpRes(404, "Não existe nenhum produto com este id");
            }

            ProdutoPorId result = new ProdutoPorId();

            return new HttpRes(200, result.Transform(produto));
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
            try
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();

                return new HttpRes(200, produto);
            }
            catch(Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }

        }

        public HttpRes Deletar(int id)
        {
            try
            {
                var produto = _context.Produtos.Include(i => i.Imagem).SingleOrDefault(p => p.ProdutoId == id);
                if (produto == null)
                {
                    return new HttpRes(404, "Não existe nenhum produto com este id");
                }
                // Remove a imagem do produto também
                //Imagem img = new Imagem { ImagemId = produto.ImagemId };
                //_context.Imagens.Attach(img);
                //_context.Imagens.Remove(img);

                _context.Remove(produto);
                _context.SaveChanges();

                return new HttpRes(204);

            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public bool existeProduto(int id)
        {
            return _context.Produtos.Any(e => e.ProdutoId == id);
        }
    }
}
