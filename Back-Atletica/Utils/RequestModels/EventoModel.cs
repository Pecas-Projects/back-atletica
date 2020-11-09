using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.RequestModels
{
    public class EventoModel
    {
        public class CriarEventoModel
        {
            [Required]
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public string Local { get; set; }
            public DateTime DataHora { get; set; }
            public double PrecoIngresso { get; set; }
            public string Cor { get; set; }
            public string NomeCategoria { get; set; }

            public Evento Transform()
            {
                Evento evento = new Evento
                {
                    Nome = Nome,
                    Descricao = Descricao,
                    Local = Local,
                    DataHora = DataHora,
                    PrecoIngresso = PrecoIngresso
                };
                return evento;
            }
        }


    }
}
