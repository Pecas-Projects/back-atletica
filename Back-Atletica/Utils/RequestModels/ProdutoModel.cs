using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.RequestModels
{
    public class ProdutoModel
    {
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required]
        public double Preco { get; set; }
        [Required]
        public int Estoque { get; set; }
        [Required]
        public int ProdutoCategoriaId { get; set; }
        [Required]
        public int AtleticaId { get; set; }
        public int ImagemId { get; set; }
        public ImagemModel Imagem { get; set; }
        public Produto Transform()
        {
            Produto produto = new Produto
            {
                Nome = Nome,
                Descricao = Descricao,
                Preco = Preco,
                Estoque = Estoque,
                ProdutoCategoriaId = ProdutoCategoriaId,
                AtleticaId = AtleticaId,
                ImagemId = ImagemId,
                Imagem = Imagem.Transform()
            };

            return produto;
        }
    }
}
