using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class JogoCategoria
    {
        public int JogoCategoriaId { get; set; }
        public string Nome { get; set; }
        public string? Cor { get; set; }
        public ICollection<Jogo> Jogos { get; set; }
        public ICollection<SolicitacaoJogo> SolicitacaoJogos { get; set; }
    }
}
