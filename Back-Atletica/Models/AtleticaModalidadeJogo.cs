using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class AtleticaModalidadeJogo
    {
        public int AtleticaModalidadeJogoId { get; set; }
        public bool? Vencedor { get; set; }
        public int AtleticaModalidadeId { get; set; }
        public AtleticaModalidade AtleticaModalidade { get; set; }
        public int JogoId { get; set; }
        public Jogo Jogo { get; set; }
    }
}
