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
                    Treinos treinos = new Treinos();

                    ModalidadesAtletica m = new ModalidadesAtletica
                    {
                        AtleticaModalidadeId = a.AtleticaModalidadeId,
                        Modalidade = a.Modalidade.Nome,
                        ImagemModalidade = a.Imagem != null ? img.Transform(a.Imagem) : null,
                        Coordenador = a.Membro != null ? a.Membro.Pessoa.Nome : null,
                        AgendaTreinos = a.AgendaTreinos != null ? treinos.Transform(a.AgendaTreinos) : null
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

        public class Treinos
        {
            public string DiaSemana { get; set; }
            public TimeSpan? HoraInicio { get; set; }
            
            public List<Treinos> Transform(ICollection<AgendaTreino> agenda)
            {
                List<Treinos> treinos = new List<Treinos>();

                foreach(var a in agenda)
                {
                    Treinos treino = new Treinos
                    {
                        DiaSemana = a.DiaSemana,
                        HoraInicio = a.HoraInicio
                    };

                    treinos.Add(treino);
                }
                

                return treinos;
            }
        }

    }
}
