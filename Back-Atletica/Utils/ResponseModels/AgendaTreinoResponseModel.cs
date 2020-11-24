using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.ResponseModels
{
    public class AgendaTreinoResponseModel
    {
        public class Treinos
        {
            public string DiaSemana { get; set; }
            public TimeSpan? HoraInicio { get; set; }

            public Treinos Transform(AgendaTreino agenda)
            {
                Treinos treino = new Treinos
                {
                    DiaSemana = agenda.DiaSemana,
                    HoraInicio = agenda.HoraInicio
                };

                return treino;
            }
        }
    }
}
