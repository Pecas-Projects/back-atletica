using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business
{
    public interface ICursoBusiness
    {
        HttpRes Create(Curso curso);

        HttpRes GetAll();

        HttpRes GetById(int id);

        HttpRes GetByName(string nome);

        HttpRes GetByAtletica(Atletica atletica);
    }
}
