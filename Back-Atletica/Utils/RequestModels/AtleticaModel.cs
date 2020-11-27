using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Back_Atletica.Utils.RequestModels.EnderecoModel;

namespace Back_Atletica.Utils.RequestModels
{
    public class AtleticaModel
    {
            [Required]
            public string Nome { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Senha { get; set; }
            [Required]
            public string Username { get; set; }
            public string Descricao { get; set; }
            public CampusModel Campus { get; set; }
            public List<int> CursosIds { get; set; }
            public List<ImagemAtleticaModel> Imagens { get; set; }

        public Atletica Transform()
            {
                Atletica atletica = new Atletica
                {
                    Nome = Nome,
                    Email = Email,
                    Senha = Senha,
                    Descricao = Descricao,
                    Campus = Campus.Transform(),
                    Username = Username
                };

                return atletica;
            }  
    }
}
