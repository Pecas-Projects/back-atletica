using Back_Atletica.Models;
using Back_Atletica.Repository;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business.Implementação
{
    public class TimeBusinessImpl : ITimeBusiness
    {
        private ITimeRepository _TimeRepository;

        public TimeBusinessImpl(ITimeRepository timeRepository)
        {
            _TimeRepository = timeRepository;
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
            return _TimeRepository.BuscarTodos(atleticaId);
        }

        public HttpRes CriarTime(TimeEscalado time)
        {
            throw new NotImplementedException();
        }

        public HttpRes Deletar(int timeId)
        {
            throw new NotImplementedException();
        }
    }
}
