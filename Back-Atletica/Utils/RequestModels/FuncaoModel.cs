using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.RequestModels
{
    public class FuncaoModel
    {
        public string Nome { get; set; }

        public Funcao Transform()
        {
            Funcao funcao = new Funcao
            {
                Nome = Nome
            };
            return funcao;
        }
    }
}
