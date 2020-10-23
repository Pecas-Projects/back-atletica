using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business
{
    public interface ITimeBusiness
    {
        HttpRes CriarTime(TimeEscalado time);
        HttpRes BuscarTodos(int atleticaId);
        HttpRes BuscarPorId(int timeId);
        HttpRes Atualizar(int timeId, TimeEscalado time);
        HttpRes Deletar(int timeId);
    }
}
