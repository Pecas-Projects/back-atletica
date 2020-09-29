using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository
{
    public interface IFuncaoRepository
    {
        HttpRes Create(Funcao funcao);

        HttpRes GetById(int id);

        HttpRes Update(Funcao funcao);

        HttpRes Delete(int id);

        bool existeFuncao(Funcao funcao);
    }
}
