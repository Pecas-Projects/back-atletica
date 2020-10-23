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
            return _TimeRepository.Atualizar(timeId, time);
        }

        public HttpRes BuscarPorId(int timeId)
        {
            return _TimeRepository.BuscarPorId(timeId);
        }

        public HttpRes BuscarTodos(int atleticaId)
        {
            return _TimeRepository.BuscarTodos(atleticaId);
        }

        public HttpRes CriarTime(TimeEscalado time)
        {
            return _TimeRepository.CriarTime(time);
        }

        public HttpRes Deletar(int timeId)
        {
            return _TimeRepository.Deletar(timeId);
        }
    }
}
