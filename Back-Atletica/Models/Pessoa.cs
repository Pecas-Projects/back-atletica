﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string Tipo { get; set; }
        public DateTime DataMatricula { get; set; }
        public char Genero { get; set; }
        public int AtleticaId { get; set; }
        public virtual Atletica Atletica { get; set; }
        public virtual Atleta Atletas { get; set; }
        public virtual Membro Membros { get; set; }

    }
}
