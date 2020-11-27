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
        HttpRes BuscaPorUsername(string username);
        HttpRes BuscaPorInstituicao(int faculdadeId);
        HttpRes Deletar(int atleticaId);
        HttpRes Atualizar(int id, Atletica atletica, List<int> CursosId, List<ImagemAtletica> ImagensIds);
        HttpRes ResetPin(int atleticaId);
        HttpRes RemoverMembro(int membroId, int atleticaId);
        HttpRes RankingAtleticas(int modalidadeId, int alteticaId);
        bool existeAtletica(int id);
    }
}
