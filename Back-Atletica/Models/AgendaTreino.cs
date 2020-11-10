using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class AgendaTreino
    {
        public int AgendaTreinoId { get; set; }
        public string DiaSemana { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public IList<AtleticaModalidadeAgendaTreino> AtleticaModalidadeAgendaTreinos { get; set; }
    }
}
