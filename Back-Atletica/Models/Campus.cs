using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Models
{
    public class Campus
    {
        public int CampusId { get; set; }
        public int FaculdadeId { get; set; }
        public virtual Faculdade Faculdade { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Nome { get; set; }
        public string Complemento { get; set; }
        public IList<Atletica> Atleticas { get; set; }
        
    }
}
