using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.ResponseModels
{
    public class AtletaJogoModel
    {
        public int AtletaAtleticaModalidadeTimeEscaladoId { get; set; }
        public int TimeEscaladoId { get; set; }
        public int AtletaAtleticaModalidadeId { get; set; }
        public int? FuncaoId { get; set; }
        public int? Numero { get; set; }
        public int? Infracoes { get; set; }
        public int? Pontos { get; set; }
        public AtletaJogoModel Transform(AtletaAtleticaModalidadeTimeEscalado aamte)
        {
            AtletaJogoModel atletaJogo = new AtletaJogoModel
            {
                AtletaAtleticaModalidadeTimeEscaladoId = aamte.AtletaAtleticaModalidadeTimeEscaladoId,
                TimeEscaladoId = aamte.TimeEscaladoId,
                AtletaAtleticaModalidadeId = aamte.AtletaAtleticaModalidadeId,
                FuncaoId = aamte.FuncaoId,
                Numero = aamte.Numero,
                Infracoes = aamte.Infracoes,
                Pontos = aamte.Pontos
            };
            return atletaJogo;
        }
    }
}
