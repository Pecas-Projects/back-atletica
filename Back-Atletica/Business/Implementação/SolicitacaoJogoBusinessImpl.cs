using Back_Atletica.Models;
using Back_Atletica.Repository;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business.Implementação
{
    public class SolicitacaoJogoBusinessImpl : ISolicitacaoJogoBusiness
    {
        private ISolicitacaoJogoRepository _SolicitacaoJogoRepository;

        public SolicitacaoJogoBusinessImpl(ISolicitacaoJogoRepository solicitacaoJogoRepository)
        {
            _SolicitacaoJogoRepository = solicitacaoJogoRepository;
        }

        public HttpRes BuscarTodas(int atleticaId)
        {
            return _SolicitacaoJogoRepository.BuscarTodas(atleticaId);
        }

        public HttpRes CriarSolicitacaoJogo(SolicitacaoJogo solicitacaoJogo, int atleticaId)
        {
            return _SolicitacaoJogoRepository.CriarSolicitacaoJogo(solicitacaoJogo, atleticaId);
        }

        public HttpRes DeletarSolicitacaoJogo(int solicitacaoAtletaId)
        {
            return _SolicitacaoJogoRepository.DeletarSolicitacaoJogo(solicitacaoAtletaId);
        }

        public HttpRes DeletarSolicitacaoJogoAprovado(int solicitacaoAtletaId)
        {
            return _SolicitacaoJogoRepository.DeletarSolicitacaoJogoAprovado(solicitacaoAtletaId);
        }
    }
}
