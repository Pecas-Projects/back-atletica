using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business
{
    public interface IModalidadeBusiness
    {
        HttpRes Criar(Modalidade modalidade);
        HttpRes CriarAtleticaModalidade(AtleticaModalidade modalidade);
        HttpRes BuscarPorTodos();
        HttpRes BuscarTodasNaAtletica(int atleticaId);
        HttpRes BuscarPorId(int id);
        HttpRes Deletar(int id);
        HttpRes ExcluiModalidadeAtletica(int atleticaId, int modalidadeId);
    }
}
