using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository.Implementação
{
    public class TimeRepositoryImpl : ITimeRepository
    {
        AtleticaContext context;

        public TimeRepositoryImpl(AtleticaContext _context)
        {
            context = _context;
        }

        public HttpRes Atualizar(int timeId, TimeEscalado time)
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscarPorId(int timeId)
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscarTodos(int atleticaId)
        {
            throw new NotImplementedException();
        }

        public HttpRes CriarTime(TimeEscalado time)
        {
            throw new NotImplementedException();
        }

        public HttpRes Deletar(int timeId)
        {
            throw new NotImplementedException();
        }

        public bool existeTime(int timeId)
        {
            throw new NotImplementedException();
        }
    }
}
