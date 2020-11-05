using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Back_Atletica.Utils.RequestModels
{
    public class AtletaModel
    {

        public class AtualizarAtletaModel
        {
            
            public bool Ativo { get; set; }

            [Required]
            public PessoaModel Pessoa { get; set; }

            public Atleta Transform()
            {

                Atleta atleta = new Atleta
                {
                    Pessoa = this.Pessoa.Transform(),
                    Ativo = Ativo
                };

                return atleta;
            }
        }
    }
}
