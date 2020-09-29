using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository.Implementação
{
    public class CursoRepositoryImpl : ICursoRepository
    {
        AtleticaContext context;

        public CursoRepositoryImpl(AtleticaContext contxt)
        {
            context = contxt;
        }

        public HttpRes Create(Curso curso)
        {
            context.Add(curso);
            context.SaveChanges();

            return new HttpRes(201, curso);
        }

        public bool existeCurso(Curso curso)
        {
            throw new NotImplementedException();
        }

        public HttpRes GetAll()
        {
            throw new NotImplementedException();
        }

        public HttpRes GetByAtletica(Atletica atletica)
        {
            throw new NotImplementedException();
        }

        public HttpRes GetById(int id)
        {
            throw new NotImplementedException();
        }

        public HttpRes GetByNome()
        {
            throw new NotImplementedException();
        }

        public HttpRes GetByNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
