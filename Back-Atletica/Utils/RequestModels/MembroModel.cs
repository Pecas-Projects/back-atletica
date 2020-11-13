using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.RequestModels
{
    public class MembroModel
    {
        public class AtualizarMembro
        {
            [Required]
            public PessoaModel Pessoa { get; set; }

            public Membro Transform()
            {
                Membro membro = new Membro
                {
                    Pessoa = this.Pessoa.Transform()                
                };

                return membro;
            }
        }
    }
}
