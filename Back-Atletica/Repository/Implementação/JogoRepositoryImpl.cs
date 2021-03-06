﻿using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using Back_Atletica.Utils.ResponseModels;
using GeradorGrafosCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Back_Atletica.Utils.ResponseModels.JogoResponseModels;

namespace Back_Atletica.Repository.Implementação
{
    public class JogoRepositoryImpl : IJogoRepository
    {
        AtleticaContext _context;

        public JogoRepositoryImpl(AtleticaContext context)
        {
            _context = context;
        }

        public HttpRes BuscarCategorias()
        {
            List<JogoCategoria> categorias = _context.JogoCategorias.ToList();

            return new HttpRes(200, categorias);
        }

        public HttpRes BuscarPorAtletica(int atleticaId)
        {
            var jogos = from j in _context.Jogos
                        join
                        jc in _context.JogoCategorias on j.JogoCategoriaId equals jc.JogoCategoriaId
                        join
                        amj in _context.AtleticaModalidadeJogos on j.JogoId equals amj.JogoId
                        join
                        am in _context.AtleticaModalidades on amj.AtleticaModalidadeId equals am.AtleticaModalidadeId
                        join
                        m in _context.Modalidades on am.ModalidadeId equals m.ModalidadeId
                        where am.AtleticaId == atleticaId
                        select new
                        {
                            j.JogoId,
                            j.DataHora,
                            m.Nome,
                            m.Genero,
                            jc.Cor
                        };

            return new HttpRes(200, jogos);
        }

        public HttpRes BuscarPorId(int id)
        {
            Jogo jogo = _context.Jogos
                .Include(j => j.JogoCategoria)
                .Include(j => j.AtleticaModalidadeJogos)
                    .ThenInclude(amj => amj.AtleticaModalidade)
                        .ThenInclude(am => am.Atletica)
                .SingleOrDefault(j => j.JogoId == id);

            if (jogo == null) return new HttpRes(404, "Não existe nenhuma atlética com este id");

            return new HttpRes(200, jogo);
        }

        public HttpRes BuscarPorModalidade(int atleticaId, int modalidadeId)
        {

            List<AtleticaModalidadeJogo> atleticaModalidadeJogos = _context.AtleticaModalidadeJogos
                .Include(amj => amj.Jogo)
                    .ThenInclude(j => j.TimeEscalados)
                        .ThenInclude(te => te.AtletaAtleticaModalidadeTimeEscalados)
                            .ThenInclude(aamte => aamte.AtletaAtleticaModalidade)
                                .ThenInclude(aam => aam.Atleta)
                                    .ThenInclude(aam => aam.Pessoa)
                .Include(amj => amj.AtleticaModalidade)
                    .ThenInclude(am => am.Atletica)
                .ToList();

            try
            {
                List<JogoResponseModels> jogosResponse = OrganizaJogosModalidade(atleticaModalidadeJogos, atleticaId, modalidadeId);
                return new HttpRes(200, jogosResponse);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }

        }


        public HttpRes Deletar(int id)
        {
            var jogo = _context.Jogos.SingleOrDefault(a => a.JogoId == id);
            if (jogo == null)
            {
                return new HttpRes(404, "Jogo não encontrado");
            }
            try
            {
                _context.Jogos.Remove(jogo);
                _context.SaveChanges();

                return new HttpRes(204);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public List<JogoResponseModels> OrganizaJogosModalidade(List<AtleticaModalidadeJogo> atleticaModalidadeJogos, int atleticaId, int modalidadeId)
        {
            List<JogoResponseModels> jogosResponse = new List<JogoResponseModels>();

            foreach (AtleticaModalidadeJogo amj in atleticaModalidadeJogos)
            {
                if (amj.AtleticaModalidade.ModalidadeId == modalidadeId)
                {
                    JogoResponseModels jogoRes = jogosResponse.SingleOrDefault(jr => jr.JogoId == amj.JogoId);

                    if (jogoRes == null)
                    {
                        jogoRes = new JogoResponseModels();
                        jogosResponse.Add(jogoRes);
                    }

                    foreach (TimeEscalado time in amj.Jogo.TimeEscalados)
                    {
                        if (time.AtleticaId == amj.AtleticaModalidade.AtleticaId)
                        {

                            TimeResponseModel timeResponse = new TimeResponseModel
                            {
                                TimeId = time.TimeEscaladoId,
                                AtleticaId = amj.AtleticaModalidade.AtleticaId,
                                Nome = amj.AtleticaModalidade.Atletica.Nome,
                                Pontos = time.PontuacaoJogo,
                                RegistrouEscalacao = time.RegistrouEscalacao
                            };

                            foreach (AtletaAtleticaModalidadeTimeEscalado atletaAtleticaModalidadeTimeEscalado in time.AtletaAtleticaModalidadeTimeEscalados)
                                if (amj.AtleticaModalidade.AtleticaId == atleticaId)
                                {
                                    AtletaJogoModel atletaJogo = new AtletaJogoModel();
                                    timeResponse.Atletas.Add(atletaJogo.Transform(atletaAtleticaModalidadeTimeEscalado));
                                }

                            if (!jogoRes.Times.Any(t => t.TimeId == timeResponse.TimeId))
                                jogoRes.Times.Add(timeResponse);
                        }
                    }

                    jogoRes.JogoId = amj.Jogo.JogoId;
                    jogoRes.DataHora = amj.Jogo.DataHora;
                }
            }

            foreach (JogoResponseModels jogoRes in jogosResponse.ToList())
                if (!jogoRes.Times.Any(t => t.AtleticaId == atleticaId))
                    jogosResponse.Remove(jogoRes);

            return jogosResponse;
        }
    }
}
