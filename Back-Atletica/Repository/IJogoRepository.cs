using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository
{
    public interface IJogoRepository
    {
        HttpRes BuscarPorAtletica(int atleticaId);
        HttpRes BuscarPorModalidade(int atleticaId, int modalidadeId);
        HttpRes BuscarCategorias();
        HttpRes BuscarPorId(int id);
        HttpRes Deletar(int id);
    }
}
