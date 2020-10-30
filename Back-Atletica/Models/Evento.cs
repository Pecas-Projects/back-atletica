using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Evento
    {
        public int EventoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
        public DateTime DataHora { get; set; }
        public double PrecoIngresso { get; set; }
        public int EventoCategoriaId { get; set; }
        public virtual EventoCategoria EventoCategoria { get; set; }
        public string Cor { get; set; }
        public int AtleticaId { get; set; }
        public virtual Atletica  Atletica { get; set; }  
    }
}
