using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Campus
    {
        public int ID { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Nome { get; set; }
        public string Complemento { get; set; }
    }
}
