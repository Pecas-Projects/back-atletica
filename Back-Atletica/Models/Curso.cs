﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Nome { get; set; }
        public int Duracao { get; set; }
        public IList<AtleticaCurso> AtleticaCursos { get; set; }
    }
}
