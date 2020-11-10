using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business
{
    public interface IJogoBusiness
    {
        HttpRes BuscarPorAtletica(int atleticaId);
        HttpRes BuscarPorModalidade(int modalidadeId, long userId);
        HttpRes BuscarCategorias();
        HttpRes BuscarPorId(int id);
        HttpRes Deletar(int id);
    }
}
