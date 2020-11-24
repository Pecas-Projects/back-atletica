using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository.Implementação
{
    public class SolicitacaoAtletaRepositoryImpl : ISolicitacaoAtletaRepository
    {
        AtleticaContext _context;

        public SolicitacaoAtletaRepositoryImpl(AtleticaContext context)
        {
            _context = context;
        }

        public HttpRes BuscarTodas(int atleticaId)
        {
            List<SolicitacaoAtleta> solicitacoesAtleta = _context.SolicitacaoAtletas
                .Where(s => s.AtleticaId == atleticaId)
                .ToList();

            return new HttpRes(200, solicitacoesAtleta);
        }

        public HttpRes CriarSolicitacaoAtletas(SolicitacaoAtleta solicitacaoAtleta, List<int> ModalidadesId)
        {
            Atletica atletica = _context.Atleticas.SingleOrDefault(a => a.AtleticaId == solicitacaoAtleta.AtleticaId);
            if(atletica == null)
            {
                return new HttpRes(404, "Atletica não encontrada");
            }

            try
            {
                solicitacaoAtleta.AtleticaId = solicitacaoAtleta.AtleticaId;
                _context.SolicitacaoAtletas.Add(solicitacaoAtleta);
                _context.SaveChanges();

                foreach (int modalidadeId in ModalidadesId)
                {
                    SolicitacaoAtletaModalidade solicitacaoAtletaModalidade = new SolicitacaoAtletaModalidade();
                    solicitacaoAtletaModalidade.SolicitacaoAtletaId = solicitacaoAtleta.SolicitacaoAtletaId;
                    solicitacaoAtletaModalidade.ModalidadeId = modalidadeId;
                    _context.SolicitacaoAtletaModalidades.Add(solicitacaoAtletaModalidade);
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }

            return new HttpRes(200, solicitacaoAtleta);
        }

        public HttpRes DeletarSolicitacaoAtletaAprovado(int solicitacaoAtletaId)
        {
            var solicitacao = _context.SolicitacaoAtletas
                .SingleOrDefault(s => s.SolicitacaoAtletaId == solicitacaoAtletaId);

            if (solicitacao == null)
            {
                return new HttpRes(404, "Solicitacao não encontrada");
            }

            try
            {
                solicitacao.Aprovado = true;
                _context.SaveChanges();

                _context.SolicitacaoAtletas.Remove(solicitacao);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }

            return new HttpRes(204);
        }

        public HttpRes DeletarSolicitacaoAtleta(int solicitacaoAtletaId)
        {
            var solicitacao = _context.SolicitacaoAtletas
                .SingleOrDefault(s => s.SolicitacaoAtletaId == solicitacaoAtletaId);

            if (solicitacao == null)
            {
                return new HttpRes(404, "Solicitacao não encontrada");
            }

            try
            {
                _context.SolicitacaoAtletas.Remove(solicitacao);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }

            return new HttpRes(204);
        }
    }
}
