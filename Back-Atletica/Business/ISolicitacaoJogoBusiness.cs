using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business
{
    public interface ISolicitacaoJogoBusiness
    {
        HttpRes CriarSolicitacaoJogo(SolicitacaoJogo solicitacaoJogo);
        HttpRes BuscarTodas(int atleticaId);
        HttpRes DeletarSolicitacaoJogo(int solicitacaoJogoId);
        HttpRes DeletarSolicitacaoJogoAprovado(int solicitacaoJogoId);
    }
}
