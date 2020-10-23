using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class AtletaAtleticaModalidade
    {
        public int AtletaAtleticaModalidadeId { get; set; }
        public int AtletaId { get; set; }
        public Atleta Atleta { get; set; }
        public int AtleticaModalidadeId { get; set; }
        public AtleticaModalidade AtleticaModalidade { get; set; }
        public IList<AtletaModalidadeTimeEscalado> AtletaModalidadeTimeEscalados { get; set; }
    }
}
