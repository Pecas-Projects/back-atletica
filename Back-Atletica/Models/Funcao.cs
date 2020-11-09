using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Funcao
    {
        public int FuncaoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<AtletaAtleticaModalidadeTimeEscalado> AtletaAtleticaModalidadeTimeEscalados { get; set; }
    }
}
