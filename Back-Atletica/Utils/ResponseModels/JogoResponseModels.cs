using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.ResponseModels
{
    public class JogoResponseModels
    {
        public int JogoId { get; set; }
        public DateTime DataHora { get; set; }
        public List<TimeResponseModel> Times { get; set; }

        public JogoResponseModels()
        {
            Times = new List<TimeResponseModel>();
        }
    }
}
