using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository
{
    public interface ISolicitacaoJogoRepository
    {
        HttpRes CriarSolicitacaoJogo(SolicitacaoJogo solicitacaoJogo);
        HttpRes BuscarTodas(int atleticaId);
        HttpRes DeletarSolicitacaoJogo(int solicitacaoAtletaId);
        HttpRes DeletarSolicitacaoJogoAprovado(int solicitacaoAtletaId);
    }
}
