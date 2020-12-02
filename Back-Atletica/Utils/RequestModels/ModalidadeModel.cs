using Back_Atletica.Models;
using Back_Atletica.Utils.ResponseModels;
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
            public List<AgendaTreinoModel> AgendaTreinos { get; set; }

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
                    Ativo = true,

                };

                if (atleticaModalidade.MembroId == 0) atleticaModalidade.MembroId = null;

                if (atleticaModalidade.ImagemId == 0) atleticaModalidade.ImagemId = null;

                atleticaModalidade.AgendaTreinos = new List<AgendaTreino>();

                if (AgendaTreinos != null)
                    foreach (AgendaTreinoModel at in AgendaTreinos)
                        atleticaModalidade.AgendaTreinos.Add(at.Transform());

                return atleticaModalidade;
            }
        }

        public class AgendaTreinoModel
        {
            public string DiaSemana { get; set; }
            public string HoraInicio { get; set; }

            public AgendaTreino Transform()
            {
                AgendaTreino treino = new AgendaTreino
                {
                    DiaSemana = DiaSemana,
                    HoraInicio = TimeSpan.Parse(HoraInicio)
                };

                return treino;
            }
        }

        public class AtualizarModalidadeAtletica
        {
            public List<AgendaTreinoModel> AgendaTreinos { get; set; }

            public int CoordenadorId { get; set; }

            [Required]
            public int ModalidadeId { get; set; }

            public int ImagemId { get; set; }

            public AtleticaModalidade Transform()
            {
                AtleticaModalidade modalidade = new AtleticaModalidade
                {
                    MembroId = this.CoordenadorId,
                    ModalidadeId = this.ModalidadeId,
                    ImagemId = this.ImagemId
                };

                if (modalidade.MembroId == 0) modalidade.MembroId = null;

                if (modalidade.ImagemId == 0) modalidade.ImagemId = null;

                modalidade.AgendaTreinos = new List<AgendaTreino>();

                if (AgendaTreinos != null)
                    foreach (AgendaTreinoModel at in AgendaTreinos)
                        modalidade.AgendaTreinos.Add(at.Transform());

                return modalidade;
            }
        }
    }
}
