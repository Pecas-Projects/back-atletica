using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository
{
    public interface IModalidadeRepository
    {
        HttpRes Criar(Modalidade modalidade);
        HttpRes CriarAtleticaModalidade(AtleticaModalidade modalidade);
        HttpRes BuscarPorTodos();
        HttpRes BuscarTodosNaAtletica(int atleticaId);
        HttpRes BuscarPorId(int id);
        HttpRes Deletar(int id);
        bool existeModalidade(int id);
    }
}
