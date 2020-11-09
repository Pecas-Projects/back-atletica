using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class ImagemAtletica
    {
        public int ImagemAtleticaId { get; set; }
        public char Tipo { get; set; }
        public int ImagemId { get; set; }
        public virtual Imagem Imagem { get; set; }
        public int AtleticaId { get; set; }
        public virtual Atletica Atletica { get; set; }
    }
}
