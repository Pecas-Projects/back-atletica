using Back_Atletica.Models;
using Back_Atletica.Repository;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Back_Atletica.Business.Implementação
{
    public class SolicitacaoAtletaBusinessImpl : ISolicitacaoAtletaBusiness
    {

        private ISolicitacaoAtletaRepository _SolicitacaoAtletaRepository;

        public SolicitacaoAtletaBusinessImpl(ISolicitacaoAtletaRepository solicitacaoAtletaRepository)
        {
            _SolicitacaoAtletaRepository = solicitacaoAtletaRepository;
        }

        public HttpRes BuscarTodas(int atleticaId)
        {
            return _SolicitacaoAtletaRepository.BuscarTodas(atleticaId);
        }

        public HttpRes CriarSolicitacaoAtletao(SolicitacaoAtleta solicitacaoAtleta, int atleticaId)
        {
            return _SolicitacaoAtletaRepository.CriarSolicitacaoAtletao(solicitacaoAtleta, atleticaId);
        }

        public HttpRes DeletarSolicitacaoAtleta(int solicitacaoAtletaId)
        {
            return _SolicitacaoAtletaRepository.DeletarSolicitacaoAtleta(solicitacaoAtletaId);
        }

        public HttpRes DeletarSolicitacaoAtletaAprovado(int solicitacaoAtletaId)
        {
            return _SolicitacaoAtletaRepository.DeletarSolicitacaoAtletaAprovado(solicitacaoAtletaId);
        }
    }
}
