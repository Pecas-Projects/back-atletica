using System;
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
        public string Whatsapp { get; set; }
        public bool Atleta { get; set; }
        public bool Membro { get; set; }
        public DateTime DataMatricula { get; set; }
        public enum Genero { M, F, I }
        public int AtleticaId { get; set; }
        public virtual Atletica Atletica { get; set; }
        public virtual Atleta Atletas { get; set; }

    }
}
