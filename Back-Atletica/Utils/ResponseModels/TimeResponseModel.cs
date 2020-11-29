using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.ResponseModels
{
    public class TimeResponseModel
    {
        public int TimeId { get; set; }
        public int AtleticaId { get; set; }
        public string Nome { get; set; }
        public int? Pontos { get; set; }
        public List<AtletaJogoModel> Atletas { get; set; }

        public TimeResponseModel()
        {
            Atletas = new List<AtletaJogoModel>();
        }
    }
}
