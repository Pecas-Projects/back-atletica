using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class TimeEscalado
    {
        public int TimeEscaladoId { get; set; }
        public string Nome { get; set; }
        public int AtleticaId { get; set; }
        public virtual Atletica Atletica { get; set; }
        public int JogoId { get; set; }
        public IList<AtletaModalidadeTimeEscalado> AtletaModalidadeTimeEscalados { get; set; }
    }
}
