using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Atletica
    {
        public int AtleticaId { get; set; }
        public int? CampusId { get; set; }
        public virtual Campus Campus { get; set; }
        public string Nome { get; set; }
        public string? Username { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string? Descricao { get; set; }
        public string PIN { get; set; }
        public string? Telefone { get; set; }
        public string? LinkProsel { get; set; }
        public ICollection<SolicitacaoAtleta> SolicitacaoAtletas { get; set; }
        public ICollection<Publicacao> Publicacoes { get; set; }
        public ICollection<ImagemAtletica> ImagemAtleticas { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        public ICollection<Evento> Eventos { get; set; }
        public ICollection<Pessoa> Pessoas { get; set; }
        public ICollection<TimeEscalado> TimeEscalados { get; set; }
        public ICollection<SolicitacaoJogo> SolicitacaoJogos { get; set; }
        public IList<AtleticaCurso> AtleticaCursos { get; set; }
        public IList<AtleticaModalidade> AtleticaModalidades { get; set; }

    }
}
