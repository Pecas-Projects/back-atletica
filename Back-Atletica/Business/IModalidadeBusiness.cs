using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business
{
    public interface IModalidadeBusiness
    {
        HttpRes Create(Modalidade modalidade);

        HttpRes GetAll();

        HttpRes GetById(int id);

        HttpRes Update(Modalidade modalidade);

        HttpRes Delete(int id);
    }
}
