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
            TimeEscalado time = new TimeEscalado();

            try
            {
                time = context.TimeEscalados.Find(timeId);
            }
            catch
            {
                return new HttpRes(404, "Erro ao conectar com o banco!");
            }

            return new HttpRes(200, time);
        }

        public HttpRes BuscarTodos(int atleticaId)
        {
            var times = new List<TimeEscalado>();

            try
            {
                times = context.TimeEscalados.Where(t => t.AtleticaId == atleticaId)
                    .ToList();
            }
            catch
            {
                return new HttpRes(404, "Erro ao conectar com o banco!");
            }

            return new HttpRes(200, times);
        }

        public HttpRes CriarTime(TimeEscalado time)
        {
            context.TimeEscalados.Add(time);
            context.SaveChanges();

            return new HttpRes(200, time);
        }

        public HttpRes Deletar(int timeId)
        {
            throw new NotImplementedException();
        }

        public bool existeTime(int timeId)
        {
            bool existe = false;

            try
            {
                existe = context.TimeEscalados.Any(t => t.TimeEscaladoId == timeId);
            }
            catch
            {
                Console.WriteLine("Ocorreu algum erro!");
            }

            return existe;
        }
    }
}
