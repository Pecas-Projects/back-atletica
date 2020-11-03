using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository
{
    public interface ISolicitacaoAtletaRepository
    {
        HttpRes CriarSolicitacaoAtletao(SolicitacaoAtleta solicitacaoAtleta, int atleticaId);
        HttpRes BuscarTodas(int atleticaId);
        HttpRes DeletarSolicitacaoAtleta(int solicitacaoAtletaId);
        HttpRes DeletarSolicitacaoAtletaAprovado(int solicitacaoAtletaId);
    }
}
