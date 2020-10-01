using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class AtleticaCurso
    {
        public int AtleticaCursoId { get; set; }
        public int AtleticaId { get; set; }
        public Atletica Atletica { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}
