using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Atleta
    {
        public int AtletaId { get; set; }
        public bool Ativo { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public IList<AtletaModalidade> AtletaModalidades { get; set; }
    }
}
