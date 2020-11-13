using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.ResponseModels
{
    public class ModalidadeResponseModels
    {
        public class ModalidadesAtletica
        {
            public string Modalidade { get; set; }
            public ImagemResponseModel ImagemModalidade { get; set; }
            public string Coordenador { get; set; }
            public List<AgendaTreino> AgendaTreinos { get; set; }

            public List<ModalidadesAtletica> Transform(List<AtleticaModalidade> atleticaModalidade)
            {

                List<ModalidadesAtletica> ma = new List<ModalidadesAtletica>();

                foreach(var a in atleticaModalidade)
                {
                    ImagemResponseModel img = new ImagemResponseModel();

                    ModalidadesAtletica m = new ModalidadesAtletica
                    {
                        Modalidade = a.Modalidade.Nome,
                        ImagemModalidade = a.Imagem != null ? img.Transform(a.Imagem) : null,
                        Coordenador = a.Membro.Pessoa.Nome,
                        AgendaTreinos = new List<AgendaTreino>(a.AgendaTreinos)
                    };

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
