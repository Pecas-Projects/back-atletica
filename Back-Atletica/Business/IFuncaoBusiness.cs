using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business
{
    public interface IFuncaoBusiness
    {
        HttpRes Create(Funcao funcao);

        HttpRes GetById(int id);

        HttpRes Update(Funcao funcao);

        HttpRes Delete(int id);
    }
}
