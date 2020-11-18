using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository
{
    public interface IAtletaRepository
    {
        HttpRes CriarAtleta(Atleta atleta);
        HttpRes BuscarTodos(int atleticaID);
        HttpRes BuscaPorID(int atletaID);
        HttpRes BuscaPorJogo(int JogoID);
        HttpRes BuscaPorModalidade(int atleticaModalidadeId);
        HttpRes BuscaAtivos(int atleticaID);
        HttpRes Atualizar(int atletaID, Atleta atleta);
        HttpRes Deletar(int atletaID);
        HttpRes AdicionarAtletaTime(int atleticaId, int jogoId, AtletaAtleticaModalidadeTimeEscalado aamte);
        HttpRes AtualizarAtletaTime(int aamteId, AtletaAtleticaModalidadeTimeEscalado aamte);
        HttpRes AdicionarAtletaModalidade(int atletaId, int atleticaModalidadeId);
        HttpRes RemoverAtletaModalidade(int atletaAtleticaModalidadeId);
        HttpRes BuscarForaModalidade(int atleticaId, int modalidadeId);
        bool ExisteAtleta(int atletaID);
    }
}
