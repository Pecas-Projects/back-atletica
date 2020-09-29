using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository
{
    public interface ICursoRepository
    {
        HttpRes Create(Curso curso);

        HttpRes GetAll();

        HttpRes GetById();

        HttpRes GetByNome(string nome);

        HttpRes GetByAtletica(Atletica atletica);

        bool existeCurso(Curso curso);
    }
}
