using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.ResponseModels
{
    public class ProdutoResponseModel
    {
        public class ProdutoPorId
        {
            public int ProdutoId { get; set; }
            public string Nome { get; set; }
            public string? Descricao { get; set; }
            public int ProdutoCategoriaId { get; set; }
            public bool Estoque { get; set; }
            public double Preco { get; set; }
            public int ImagemId { get; set; }
            public ImagemResponseModel Imagem { get; set; }
            public int AtleticaId { get; set; }

            public ProdutoPorId Transform(Produto produto)
            {
                ProdutoPorId p = new ProdutoPorId
                {
                    ProdutoId = produto.ProdutoId,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao != null ? produto.Descricao : null,
                    ProdutoCategoriaId = produto.ProdutoCategoriaId,
                    Estoque = produto.Estoque,
                    Preco = produto.Preco,
                    ImagemId = produto.ImagemId,
                    Imagem = new ImagemResponseModel().Transform(produto.Imagem),
                    AtleticaId = produto.AtleticaId
                };

                return p;
            }
        }
    }
}
