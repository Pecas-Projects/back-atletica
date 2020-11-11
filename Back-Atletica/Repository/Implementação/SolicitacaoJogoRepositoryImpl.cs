using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository.Implementação
{
    public class SolicitacaoJogoRepositoryImpl : ISolicitacaoJogoRepository
    {

        AtleticaContext _context;

        public SolicitacaoJogoRepositoryImpl(AtleticaContext context)
        {
            _context = context;
        }

        public HttpRes BuscarTodas(int atleticaId)
        {
            throw new NotImplementedException();
        }

        public HttpRes CriarSolicitacaoJogo(SolicitacaoJogo solicitacaoJogo, int atleticaId)
        {
            throw new NotImplementedException();
        }

        public HttpRes DeletarSolicitacaoJogo(int solicitacaoAtletaId)
        {
            throw new NotImplementedException();
        }

        public HttpRes DeletarSolicitacaoJogoAprovado(int solicitacaoAtletaId)
        {
            throw new NotImplementedException();
        }
    }
}
