using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class AtletaModalidadeTimeEscalado
    {
        public int AtletaModalidadeTimeEscaladoId { get; set; }
        public int TimeEscaladoId { get; set; }
        public virtual TimeEscalado TimeEscalado { get; set; }
        public int AtletaModalidadeId { get; set; }
        public virtual AtletaModalidade AtletaModalidade { get; set; }
        public int FuncaoId { get; set; }
        public virtual Funcao Funcao { get; set; }
        public int Numero { get; set; }
        public int Infracoes { get; set; }
        public int Pontos { get; set; }
        
    }
}
