using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Imagem
    {
        public int ImagemId { get; set; }
        public int AtleticaId { get; set; }
        public string Nome { get; set; }
        public string Path { get; set; }
        public string Extensao { get; set; }
    }
}
