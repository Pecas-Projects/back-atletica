using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Back_Atletica.Utils.ResponseModels.AgendaTreinoResponseModel;

namespace Back_Atletica.Utils.ResponseModels
{
    public class ModalidadeResponseModels
    {
        public class ModalidadesAtletica
        {
            public int AtleticaModalidadeId { get; set; }
            public string Modalidade { get; set; }
            public ImagemResponseModel ImagemModalidade { get; set; }
            public string Coordenador { get; set; }
            public List<Treinos> AgendaTreinos { get; set; }

            public List<ModalidadesAtletica> Transform(List<AtleticaModalidade> atleticaModalidade)
            {
                List<ModalidadesAtletica> ma = new List<ModalidadesAtletica>();

                foreach(var a in atleticaModalidade)
                {
                    ImagemResponseModel img = new ImagemResponseModel();

                    ModalidadesAtletica m = new ModalidadesAtletica
                    {
                        AtleticaModalidadeId = a.AtleticaModalidadeId,
                        Modalidade = a.Modalidade.Nome,
                        ImagemModalidade = a.Imagem != null ? img.Transform(a.Imagem) : null,
                        Coordenador = a.Membro != null ? a.Membro.Pessoa.Nome : null
                    };

                    if(a.AgendaTreinos != null)
                    {
                        foreach (var t in a.AgendaTreinos)
                        {
                            Treinos agenda = new Treinos();

                            m.AgendaTreinos.Add(agenda.Transform(t));
                        }
                    }                   

                    ma.Add(m);
                }

                return ma;
            }

        }

        public class Coordenador
        {
            public string Nome { get; set; }

            public Coordenador Transform(Pessoa pessoa)
            {
                Coordenador membro = new Coordenador
                {
                    Nome = pessoa.Nome
                };

                return membro;
            }
        }      

    }
}
