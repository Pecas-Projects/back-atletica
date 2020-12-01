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
        public int AtletaId { get; set; }
        public string Nome { get; set; }
        public int? FuncaoId { get; set; }
        public int? Numero { get; set; }
        public int? Infracoes { get; set; }
        public int? Pontos { get; set; }
        public AtletaJogoModel Transform(AtletaAtleticaModalidadeTimeEscalado atletaAtleticaModalidadeTimeEscalado)
        {
            AtletaJogoModel atletaJogo = new AtletaJogoModel
            {
                AtletaAtleticaModalidadeTimeEscaladoId = atletaAtleticaModalidadeTimeEscalado.AtletaAtleticaModalidadeTimeEscaladoId,
                TimeEscaladoId = atletaAtleticaModalidadeTimeEscalado.TimeEscaladoId,
                AtletaAtleticaModalidadeId = atletaAtleticaModalidadeTimeEscalado.AtletaAtleticaModalidadeId,
                FuncaoId = atletaAtleticaModalidadeTimeEscalado.FuncaoId,
                AtletaId = atletaAtleticaModalidadeTimeEscalado.AtletaAtleticaModalidade.AtletaId,
                Nome = atletaAtleticaModalidadeTimeEscalado.AtletaAtleticaModalidade.Atleta.Pessoa.Nome + " " + atletaAtleticaModalidadeTimeEscalado.AtletaAtleticaModalidade.Atleta.Pessoa.Sobrenome,
                Numero = atletaAtleticaModalidadeTimeEscalado.Numero,
                Infracoes = atletaAtleticaModalidadeTimeEscalado.Infracoes,
                Pontos = atletaAtleticaModalidadeTimeEscalado.Pontos
            };
            return atletaJogo;
        }
    }
}
