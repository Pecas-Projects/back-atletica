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
            [Required]
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
    }
}
