using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Publicacao
    {
        public int PublicacaoId { get; set; }
        public int ImagemId { get; set; }
        public int AtleticaId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
