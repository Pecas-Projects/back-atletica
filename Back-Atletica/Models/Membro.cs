using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Membro
    {
        public int MembroId { get; set; }
        public string Senha { get; set; }
        public int PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public int? ImagemId { get; set; }
        public virtual Imagem Imagem { get; set; }
        public ICollection<AtleticaModalidade> AtleticaModalidades { get; set; }
    }
}
