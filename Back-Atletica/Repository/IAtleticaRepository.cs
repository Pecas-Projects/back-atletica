using Back_Atletica.Models;
using Back_Atletica.Utils;
using System.Collections.Generic;

namespace Back_Atletica.Repository
{
    public interface IAtleticaRepository
    {
        HttpRes BuscarTodos();
        HttpRes BuscaPorId(int id);
        HttpRes BuscaPorNome(string nome);
        HttpRes BuscaPorInstituicao(int faculdadeId);
        HttpRes Deletar(int atleticaId);
        HttpRes Atualizar(int id, Atletica atletica, List<int> CursosId);
        HttpRes ResetPin(int atleticaId);
        bool existeAtletica(int id);
    }
}
