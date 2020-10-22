using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class ProdutoCategoria
    {
        public int ProdutoCategoriaId { get; set; }
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
