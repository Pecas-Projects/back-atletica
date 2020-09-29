using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class AtletaModalidade
    {
        public int AtletaModalidadeId { get; set; }
        public int AtletaId { get; set; }
        public int ModalidadeId { get; set; }
        public virtual Atleta Atleta { get; set; }
        public virtual Atleta Modalidade { get; set; }
        public IList<AtletaModalidadeTimeEscalado> AtletaModalidadeTimeEscalados { get; set; }
    }
}
