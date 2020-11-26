using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.RequestModels
{
    public class ImagemAtleticaModel
    {
        [Required]
        public char Tipo { get; set; }
        public int ImagemId { get; set; }

        public ImagemAtletica Transform()
        {
            return new ImagemAtletica
            {
                Tipo = this.Tipo,
                ImagemId = this.ImagemId
            };
        }
    }
}
