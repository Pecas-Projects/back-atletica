using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Modalidade
    {
        public int ModalidadeId { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public IList<AtleticaModalidade> AtleticaModalidades { get; set; }
        public ICollection<SolicitacaoJogo> SolicitacaoJogos { get; set; }
        public ICollection<SolicitacaoAtletaModalidade> SolicitacaoAtletaModalidades { get; set; }
    }
}
