﻿using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Back_Atletica.Utils.ResponseModels.SolicitacaoJogoResponseModels;

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

            List<SolicitacaoJogo> solicitacoesJogo = 
                _context.SolicitacaoJogos
                .Include(s => s.Modalidade)
                .Include(s => s.AtleticaAdversaria)
                .Include(s => s.JogoCategoria)
                .Where(s => s.AtleticaId == atleticaId)
                .ToList();

            List<SolicitacaoJogoResponse> solicitacaoJogoResponses = new List<SolicitacaoJogoResponse>();

            foreach (SolicitacaoJogo solicitacao in solicitacoesJogo)
            {
                SolicitacaoJogoResponse s = new SolicitacaoJogoResponse();
                solicitacaoJogoResponses.Add(s.Transform(solicitacao));
            }

            return new HttpRes(200, solicitacaoJogoResponses);
        }

        public HttpRes CriarSolicitacaoJogo(SolicitacaoJogo solicitacaoJogo)
        {
            Atletica atletica = _context.Atleticas.SingleOrDefault(a => a.AtleticaId == solicitacaoJogo.AtleticaAdversariaId);
            if (atletica == null)
            {
                return new HttpRes(404, "Atletica não encontrada");
            }

            Atletica atleticaConvidada = _context.Atleticas.SingleOrDefault(a => a.AtleticaId == solicitacaoJogo.AtleticaId);
            if (atleticaConvidada == null)
            {
                return new HttpRes(404, "Atletica convidada não encontrada");
            }

            AtleticaModalidade atleticaModalidade =
                _context.AtleticaModalidades
                .SingleOrDefault(am => am.AtleticaId == atletica.AtleticaId && am.ModalidadeId == solicitacaoJogo.ModalidadeId && am.Ativo == true);

            if (atleticaModalidade == null)
            {
                return new HttpRes(404, "A atletica não tem essa modalidade cadastrada");
            }

            AtleticaModalidade atleticaModalidadeConvidada =
                _context.AtleticaModalidades
                .SingleOrDefault(am => am.AtleticaId == atleticaConvidada.AtleticaId && am.ModalidadeId == solicitacaoJogo.ModalidadeId && am.Ativo == true);

            if (atleticaModalidadeConvidada == null)
            {
                return new HttpRes(404, "A atletica convidada não tem essa modalidade cadastrada");
            }

            try
            {
                _context.SolicitacaoJogos.Add(solicitacaoJogo);
                _context.SaveChanges();

                return new HttpRes(200, solicitacaoJogo);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public HttpRes DeletarSolicitacaoJogo(int solicitacaoJogoId)
        {
            var solicitacao = _context.SolicitacaoJogos
                .SingleOrDefault(s => s.SolicitacaoJogoId == solicitacaoJogoId);

            if (solicitacao == null)
            {
                return new HttpRes(404, "Solicitacao não encontrada");
            }

            try
            {
                _context.SolicitacaoJogos.Remove(solicitacao);
                _context.SaveChanges();
                return new HttpRes(204);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public HttpRes DeletarSolicitacaoJogoAprovado(int solicitacaoJogoId)
        {
            var solicitacao = _context.SolicitacaoJogos
                .SingleOrDefault(s => s.SolicitacaoJogoId == solicitacaoJogoId);

            if (solicitacao == null)
            {
                return new HttpRes(404, "Solicitacao não encontrada");
            }

            try
            {
                solicitacao.Aprovado = true;
                _context.SaveChanges();

                _context.SolicitacaoJogos.Remove(solicitacao);
                _context.SaveChanges();
                return new HttpRes(204);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }
        }
    }
}
