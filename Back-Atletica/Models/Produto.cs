using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public double Preco { get; set; }
        public int Estoque { get; set; }


        public int ImagemId { get; set; }
        public virtual Imagem Imagem { get; set; }

        public int AtleticaId { get; set; }
        public virtual Atletica Atletica { get; set; }
}}
