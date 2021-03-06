﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class TimeEscalado
    {
        public int TimeEscaladoId { get; set; }
        public int AtleticaId { get; set; }
        public virtual Atletica Atletica { get; set; }
        public int JogoId { get; set; }
        public int PontuacaoJogo { get; set; }
        public bool RegistrouEscalacao { get; set; } //a atlética preencheu o forms de pós jogo
        public virtual Jogo Jogos { get; set; }
        public IList<AtletaAtleticaModalidadeTimeEscalado> AtletaAtleticaModalidadeTimeEscalados { get; set; }
    }
}
