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

            public AtleticaModalidade Transform()
            {
                AtleticaModalidade atleticaModalidade = new AtleticaModalidade
                {
                    ModalidadeId = this.ModalidadeId,
                    MembroId = this.CoordenadorId,
                    ImagemId = this.ImagemId,
                    Ativo = true
                };

                if (atleticaModalidade.MembroId == 0) atleticaModalidade.MembroId = null;

                if (atleticaModalidade.ImagemId == 0) atleticaModalidade.ImagemId = null;

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
                    ImagemId = this.ImagemId,
                    AtleticaId = this.AtleticaId
                };

                if (modalidade.MembroId == 0) modalidade.MembroId = null;

                if (modalidade.ImagemId == 0) modalidade.ImagemId = null;

                return modalidade;
            }
        }
    }
}
