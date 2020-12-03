using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.RequestModels
{
    public class AtletaAtleticaModalidadeTimeEscaladoModel
    {
        public class CriarAtletaAtleticaModalidadeTimeEscaladoModel
        {
            [Required]
            public int AtletaAtleticaModalidadeId { get; set; }
            public FuncaoModel Funcao { get; set; }
            public int Numero { get; set; }
            public int Pontos { get; set; }
            public int Infracoes { get; set; }
            public AtletaAtleticaModalidadeTimeEscalado Transform()
            {
                AtletaAtleticaModalidadeTimeEscalado atletaAtleticaModalidadeTimeEscalado = new AtletaAtleticaModalidadeTimeEscalado
                {
                    AtletaAtleticaModalidadeId = AtletaAtleticaModalidadeId,
                    Funcao = Funcao == null ? null : Funcao.Transform(),
                    Numero = Numero,
                    Pontos = Pontos,
                    Infracoes = Infracoes
                };

                return atletaAtleticaModalidadeTimeEscalado;
            }
        }

        public class AtualizarAtletaAtleticaModalidadeTimeEscaladoModel
        {
            public int FuncaoId { get; set; }
            public int Numero { get; set; }
            public int Pontos { get; set; }
            public int Infracoes { get; set; }
            public AtletaAtleticaModalidadeTimeEscalado Transform()
            {
                AtletaAtleticaModalidadeTimeEscalado atletaAtleticaModalidadeTimeEscalado = new AtletaAtleticaModalidadeTimeEscalado
                {
                    FuncaoId = FuncaoId,
                    Numero = Numero,
                    Pontos = Pontos,
                    Infracoes = Infracoes
                };

                if (atletaAtleticaModalidadeTimeEscalado.FuncaoId == 0) atletaAtleticaModalidadeTimeEscalado.FuncaoId = null;

                return atletaAtleticaModalidadeTimeEscalado;
            }
        }
    }
}
