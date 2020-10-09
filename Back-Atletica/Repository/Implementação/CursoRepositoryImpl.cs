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

        public HttpRes Criar(Curso curso)
        {
            if (!existeCurso(curso))
            {
                context.Add(curso);
                context.SaveChanges();

                return new HttpRes(201, curso);
            }

            return new HttpRes(400, "O curso já existe!");
        }

        public bool existeCurso(Curso curso)
        {
            bool existe = false;

            try
            {
                existe = context.Cursos.Any(c => c.Nome == curso.Nome);
            }
            catch
            {
                Console.WriteLine("Ocorreu algum erro!");
            }
            return existe;
        }

        public HttpRes BuscarTodos()
        {
            var cursos = context.Cursos.ToList<Curso>();

            return new HttpRes(200, cursos);
        }


        public HttpRes BuscarPorId(int id)
        {

            throw new NotImplementedException();
        }

        public HttpRes BuscarPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
