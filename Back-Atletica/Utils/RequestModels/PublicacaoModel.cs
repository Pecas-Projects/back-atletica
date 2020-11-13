using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.RequestModels
{
    public class PublicacaoModel
    {
        [Required]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        [Required]
        public int AtleticaId { get; set; }
        public int ImagemId { get; set; }
        public Publicacao Transform()
        {
            Publicacao publicacao = new Publicacao
            {
                Titulo = Titulo,
                Descricao = Descricao,
                ImagemId = ImagemId,
                AtleticaId = AtleticaId
            };
            return publicacao;

        }
    }
}
