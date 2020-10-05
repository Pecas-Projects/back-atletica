using Back_Atletica.Models;
using Back_Atletica.Repository;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business.Implementação
{
    public class CursoBusinessImpl : ICursoBusiness
    {
        private ICursoRepository _CursoRepository;

        public CursoBusinessImpl(ICursoRepository cursoRepository)
        {
            _CursoRepository = cursoRepository;
        }

        public HttpRes Criar(Curso curso)
        {
            return _CursoRepository.Criar(curso);
        }

        public HttpRes BuscarTodos()
        {
            return _CursoRepository.BuscarTodos();
        }

        public HttpRes BuscarPorId(int id)
        {
            return _CursoRepository.BuscarPorId(id);
        }


        public HttpRes BuscarPorNome(string nome)
        {
            return _CursoRepository.BuscarPorNome(nome);
        }
    }
}
