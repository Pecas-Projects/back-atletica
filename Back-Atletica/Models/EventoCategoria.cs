using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class EventoCategoria
    {
        public int EventoCategoriaId { get; set; }
        public string Nome { get; set; }
        public string? Cor { get; set; }
        public ICollection<Evento> Eventos { get; set; }
    }
}
