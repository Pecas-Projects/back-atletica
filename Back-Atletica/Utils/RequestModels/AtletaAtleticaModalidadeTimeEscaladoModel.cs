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
        [Required]
        public int AtletaAtleticaModalidadeId { get; set; }
        public int FuncaoId { get; set; }
        public int Numero { get; set; }
        public int Pontos { get; set; }
        public int Infracoes { get; set; }
        public AtletaAtleticaModalidadeTimeEscalado Transform()
        {
            AtletaAtleticaModalidadeTimeEscalado aamte = new AtletaAtleticaModalidadeTimeEscalado
            {
                AtletaAtleticaModalidadeId = AtletaAtleticaModalidadeId,
                FuncaoId = FuncaoId,
                Numero = Numero,
                Pontos = Pontos,
                Infracoes = Infracoes
            };
            return aamte;
        }
    }
}
