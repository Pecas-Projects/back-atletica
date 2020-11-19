using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.ResponseModels
{
    public class JogoResponseModels
    {
        public JogoResponseModels()
        {
            Atleticas = new List<AtleticaJogoModel>();
            Atletas = new List<AtletaJogoModel>();
        }

        public int JogoId { get; set; }
        public DateTime DataHora { get; set; }
        public List<AtleticaJogoModel> Atleticas { get; set; }
        public List<AtletaJogoModel> Atletas { get; set; }

        public class AtleticaJogoModel
        {
            public int AtleticaId { get; set; }
            public string Nome { get; set; }
            public int? Pontos { get; set; }
        }

        public class AtletaJogoModel
        {
            public int AtletaAtleticaModalidadeTimeEscaladoId { get; set; }
            public int TimeEscaladoId { get; set; }
            public int AtletaAtleticaModalidadeId { get; set; }
            public int? FuncaoId { get; set; }
            public int? Numero { get; set; }
            public int? Infracoes { get; set; }
            public int? Pontos { get; set; }
        }
    }
}
