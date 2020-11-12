using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.RequestModels
{
    public class ImagemModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public string Extensao { get; set; }
        public Imagem Transform()
        {

            Imagem img = new Imagem
            {
                Nome = Nome,
                Path = Path,
                Extensao = Extensao
            };

            return img;
        }
    }
}
