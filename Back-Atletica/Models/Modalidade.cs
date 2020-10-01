using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Modalidade
    {
        public int ModalidadeId { get; set; }
        public string Nome { get; set; }
        public enum Genero { M, F, MF }
        public string NomeCoordenador { get; set; }
        public IList<AtletaModalidade> AtletaModalidades { get; set; }
    }
}
