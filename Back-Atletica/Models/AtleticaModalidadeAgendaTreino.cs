using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class AtleticaModalidadeAgendaTreino
    {
        public int AtleticaModalidadeAgendaTreinoId { get; set; }
        public int AtleticaModalidadeId { get; set; }
        public AtleticaModalidade AtleticaModalidade { get; set; }
        public int AgendaTreinoId { get; set; }
        public AgendaTreino AgendaTreino { get; set; }
    }
}
