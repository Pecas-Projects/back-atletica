using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.RequestModels
{
    public class ModalidadeModel
    {

        public class ModalidadeAtletica
        {
            
            public int CoordenadorId { get; set; }

            [Required]
            public int ModalidadeId { get; set; }

            public int ImagemId { get; set; }

            public AtleticaModalidade Transform(int atleticaId)
            {
                AtleticaModalidade atleticaModalidade = new AtleticaModalidade
                {
                    ModalidadeId = this.ModalidadeId,
                    MembroId = this.CoordenadorId,
                    AtleticaId = atleticaId,
                    ImagemId = this.ImagemId
                };

                return atleticaModalidade;
            }
        }

        public class AtualizarModalidadeAtletica
        {
            public int CoordenadorId { get; set; }

            [Required]
            public int ModalidadeId { get; set; }

            public int ImagemId { get; set; }

            [Required]
            public int AtleticaId { get; set; }

            public AtleticaModalidade Transform()
            {
                AtleticaModalidade modalidade = new AtleticaModalidade
                {
                    MembroId = this.CoordenadorId,
                    ModalidadeId = this.ModalidadeId,
                    ImagemId = this.ModalidadeId,
                    AtleticaId = this.AtleticaId
                };

                return modalidade;
            }
        }
    }
}
