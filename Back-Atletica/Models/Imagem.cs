using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Imagem
    {
        public int ImagemId { get; set; }
        public string PublicId { get; set; }
        public string Path { get; set; }
        public string Extensao { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Publicacao Publicacao { get; set; }
        public virtual AtleticaModalidade AtleticaModalidade { get; set; }
        public virtual Membro Membro { get; set; }
        public virtual ImagemAtletica ImagemAtletica { get; set; }
    }
}
