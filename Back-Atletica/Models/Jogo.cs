using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Jogo
    {
        public int JogoId { get; set; }
        public string Nome { get; set; }
        public int JogoCategoriaId { get; set; }
        public JogoCategoria JogoCategoria { get; set; }
        public DateTime DataHora { get; set; }
        public string Local { get; set; }
        public ICollection<TimeEscalado> TimeEscalados { get; set; }

    }
}
