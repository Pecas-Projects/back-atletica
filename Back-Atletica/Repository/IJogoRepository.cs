using Back_Atletica.Models;
using Back_Atletica.Utils;
using Back_Atletica.Utils.ResponseModels;
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
        List<JogoResponseModels> OrganizaJogosModalidade(List<AtleticaModalidadeJogo> atleticaModalidadeJogos, int atleticaId, int modalidadeId);
        void CalculaRanking(int modalidadeId);
    }
}
