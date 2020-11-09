using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class SolicitacaoAtleta
    {
        public int SolicitacaoAtletaId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string WhatsApp { get; set; }
        public string Email { get; set; }
        public bool Aprovado { get; set; }
        public DateTime AnoEntradaFacul { get; set; }
        public int AtleticaId { get; set; }
        public virtual Atletica Atletica { get; set; }
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }
        public ICollection<SolicitacaoAtletaModalidade> SolicitacaoAtletaModalidades { get; set; }
    }
}
