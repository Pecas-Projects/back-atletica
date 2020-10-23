using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class AtleticaModalidade
    {
        public int AtleticaModalidadeId { get; set; }
        public int AtleticaId { get; set; }
        public Atletica Atletica { get; set; }
        public int ModalidadeId { get; set; }
        public Modalidade Modalidade { get; set; }
        public string NomeCoordenador { get; set; }
        public ICollection<AtletaAtleticaModalidade> AtletaAtleticaModalidades { get; set; }
    }
}
