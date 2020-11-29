using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.ResponseModels
{
    public class AtleticaModalidadeResponseModels
    {
        public class AtleticaModalidadeResponse
        {
            public int AtleticaModalidadeId { get; set; }
            public int PosicaoRanking { get; set; }
            public int NumeroJogos { get; set; }
            public AtleticaResponseModel Atletica{ get; set; }

            public AtleticaModalidadeResponse Transform(AtleticaModalidade atleticaModalidade)
            {
                AtleticaModalidadeResponse am = new AtleticaModalidadeResponse
                {
                    AtleticaModalidadeId = atleticaModalidade.AtleticaModalidadeId,
                    PosicaoRanking = (int)atleticaModalidade.PosicaoRanking + 1
                };

                if(atleticaModalidade.Atletica != null)
                {
                    AtleticaResponseModel atletica = new AtleticaResponseModel();
                    am.Atletica = atletica.Transform(atleticaModalidade.Atletica);
                }

                return am;
            }
        }

            
    }

    public class AtleticaResponseModel
    {

        public int AtleticaId { get; set; }
        public string Nome { get; set; }
        public string NomeFaculdade { get; set; }
        public ImagemAtleticasResponseModel LogoAtletica { get; set; }
        public CampusResponseModel Campus { get; set; }

        public AtleticaResponseModel Transform(Atletica atletica)
        {
            AtleticaResponseModel a = new AtleticaResponseModel
            {
                Nome = atletica.Nome,
                AtleticaId = atletica.AtleticaId,
            };
            if (atletica.Campus != null)
            {
                CampusResponseModel campus = new CampusResponseModel();
                a.Campus = campus.Transform(atletica.Campus);
            }
            if (atletica.ImagemAtleticas.Count > 0)
            {
                ImagemAtleticasResponseModel img = new ImagemAtleticasResponseModel();

                foreach (ImagemAtletica i in atletica.ImagemAtleticas)
                {
                    if (i != null && i.Tipo == 'P')
                    {
                        img = img.Transform(i);
                    }
                }
                a.LogoAtletica = img;
            }
            return a;
        }
    }       
}
