using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class SolicitacaoJogo
    {
        public int SolicitacaoJogoId { get; set; }
        public bool Aprovado { get; set; }
        public DateTime DataHora { get; set; }
        public string Local { get; set; }
        public int AtleticaId { get; set; }
        public Atletica Atletica { get; set; }
        public int AtleticaAdversariaId { get; set; }
        public Atletica AtleticaAdversaria { get; set; }
        public int JogoCategoriaId { get; set; }
        public JogoCategoria JogoCategoria { get; set; }
        public int ModalidadeId { get; set; }
        public Modalidade Modalidade { get; set; }
    }
}
