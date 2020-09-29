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

        public HttpRes Create(Curso curso)
        {
            return _CursoRepository.Create(curso);
        }

        public HttpRes GetAll()
        {
            return _CursoRepository.GetAll();
        }

        public HttpRes GetByAtletica(Atletica atletica)
        {
            return _CursoRepository.GetByAtletica(atletica);
        }

        public HttpRes GetById(int id)
        {
            return _CursoRepository.GetById(id);
        }


        public HttpRes GetByName(string nome)
        {
            return _CursoRepository.GetByNome(nome);
        }
    }
}
