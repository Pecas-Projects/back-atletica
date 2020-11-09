using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class SolicitacaoAtletaModalidade
    {
        public int SolicitacaoAtletaModalidadeId { get; set; }
        public int SolicitacaoAtletaId { get; set; }
        public SolicitacaoAtleta SolicitacaoAtleta { get; set; }
        public int ModalidadeId { get; set; }
        public Modalidade Modalidade { get; set; }
    }
}
