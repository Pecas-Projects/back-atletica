﻿using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
            try
            {
                if (!existeCurso(curso))
                {
                    context.Add(curso);
                    context.SaveChanges();

                    return new HttpRes(201, curso);
                }

                return new HttpRes(400, "O curso já existe!");
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }

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
            List<Curso> cursos = new List<Curso>();

            cursos = context.Cursos
                .OrderBy(c => c.Nome)
                .ToList();

            return new HttpRes(200, cursos);
        }


        public HttpRes BuscarPorId(int id)
        {
            Curso curso = new Curso();

            curso = context.Cursos.Find(id);

            return new HttpRes(200, curso);
        }

        public HttpRes BuscarPorNome(string nome)
        {
            var cursos = new List<Curso>();

            cursos = context.Cursos.Where(c => c.Nome.ToUpper().Contains(nome.ToUpper()))
                .OrderBy(c => EF.Functions.Like(c.Nome.ToUpper(), nome.ToUpper() + "%") ? 1 :
                EF.Functions.Like(c.Nome.ToUpper(), "%" + nome.ToUpper()) ? 3 : 2)
                .ToList();

            return new HttpRes(200, cursos);
        }
    }
}
