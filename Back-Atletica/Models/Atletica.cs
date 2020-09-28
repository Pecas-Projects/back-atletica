using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Atletica
    {
        public int AtleticaId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Descricao { get; set; }

        public string PIN { get; set; }

        public string Faculdade { get; set; }
    }
}
