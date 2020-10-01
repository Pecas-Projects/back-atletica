using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Jogo
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public DateTime DataHora { get; set; }
        public string Local { get; set; }
        public IList<TimeEscalado> TimeEscalados { get; set; }
    }
}
