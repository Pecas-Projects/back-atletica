using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business
{
    public interface IAtletaBusiness
    {
        HttpRes CriarAtleta(Atleta atleta);
        HttpRes BuscarTodos(int atleticaID);
        HttpRes BuscaPorID(int atletaID);
        HttpRes BuscaPorTime(int timeEscaladoID);
        HttpRes BuscaPorModalidade(int modalidadeID);
        HttpRes BuscaAtivos(int atleticaID);
        HttpRes Atualizar(int atletaID, Atleta atleta);
        HttpRes Deletar(int atletaID);
    }
}
