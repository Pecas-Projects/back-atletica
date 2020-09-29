using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Atletica
    {
        public int AtleticaId { get; set; }
        public int CampusId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Descricao { get; set; }
        public string PIN { get; set; }
        public virtual Campus Campus { get; set; }
        public IList<SolicitacaoAtleta> SolicitacaoAtletas { get; set; }
        public IList<Curso> Cursos { get; set; }
        public IList<Publicacao> Publicacoes { get; set; }
        public IList<Imagem> imagens { get; set; }
        public IList<Produto> Produtos { get; set; }
        public IList<Evento> Eventos { get; set; }
        public IList<Pessoa> Pessoas { get; set; }
        public IList<TimeEscalado> TimeEscalados { get; set; }

    }
}
