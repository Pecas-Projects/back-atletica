﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Jogo
    {
        public int JogoId { get; set; }
        public int JogoCategoriaId { get; set; }
        public JogoCategoria JogoCategoria { get; set; }
        public DateTime DataHora { get; set; }
        public string Local { get; set; }
        public bool Finalizado { get; set; } //as duas atléticas já preencheram o forms de pós jogo
        public ICollection<TimeEscalado> TimeEscalados { get; set; }
        public IList<AtleticaModalidadeJogo> AtleticaModalidadeJogos { get; set; }

    }
}
