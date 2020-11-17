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
        public bool Ativo { get; set; }
        public IList<AtletaAtleticaModalidadeTimeEscalado> AtletaAtleticaModalidadeTimeEscalados { get; set; }
    }
}
