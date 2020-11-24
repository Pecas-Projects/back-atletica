using Back_Atletica.Data;
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
            this.CalculaRanking(modalidadeId);

            List<AtleticaModalidadeJogo> atleticaModalidadeJogos = _context.AtleticaModalidadeJogos
                .Include(amj => amj.Jogo)
                    .ThenInclude(j => j.TimeEscalados)
                        .ThenInclude(te => te.AtletaAtleticaModalidadeTimeEscalados)
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

        public void CalculaRanking(int modalidadeId)
        {
            Grafo grafo = new Grafo();
            List<double> posicoes = new List<double>();
            List<AtleticaModalidade> atleticas = _context.AtleticaModalidades.Where(am => am.ModalidadeId == modalidadeId).ToList();

            //List<AtleticaModalidadeJogo>AMJ = _context.AtleticaModalidadeJogos.Where(a => a.)

            var jogos = from amj in _context.AtleticaModalidadeJogos
                        join
                        am in _context.AtleticaModalidades on amj.AtleticaModalidadeId equals am.AtleticaModalidadeId
                        where am.ModalidadeId == modalidadeId
                        select new
                        {
                            amj.AtleticaModalidadeId,
                            amj.JogoId,
                            amj.Vencedor
                        };

            foreach (AtleticaModalidade am in atleticas)
            {
                Vertice v = new Vertice();
                v.id = am.AtleticaModalidadeId;
                v.etiqueta = am.AtleticaId.ToString();
                grafo.AdicionaVertice(v);
            }

            foreach (var jogo in jogos)
            {
                List<AtleticaModalidadeJogo> participantes = _context.AtleticaModalidadeJogos.Where(amj => amj.JogoId == jogo.JogoId).ToList();
                List<AtleticaModalidadeJogo> vencedores = _context.AtleticaModalidadeJogos.Where(amj => amj.JogoId == jogo.JogoId && amj.Vencedor == true).ToList();
                
                foreach ( AtleticaModalidadeJogo amj in participantes)
                {
                    if (amj.Vencedor == false)
                    {
                        foreach (AtleticaModalidadeJogo vencedor in vencedores)
                        {
                            Arco a = new Arco();
                            a.saida = grafo.ProcuraVertice(amj.AtleticaModalidadeId);
                            a.entrada = grafo.ProcuraVertice(vencedor.AtleticaModalidadeId);
                            grafo.AdicionarArco(a);
                        }
                    }
                }           
            }

            grafo.PageRank();
            int cont = 0;

            foreach (Vertice v in grafo.Vertices)
            {
                posicoes.Add(v.PageRank[(v.PageRank.Count - 1)]);
            }

            posicoes.Sort();
            posicoes.Reverse();

            foreach (Vertice v in grafo.Vertices)
            {
                v.PosicaoRank = posicoes.IndexOf(v.PageRank[(v.PageRank.Count - 1)]);
            }

            foreach (Vertice v in grafo.Vertices)
            {
                atleticas[cont].PosicaoRanking = v.PosicaoRank;
                cont++;
            }

            _context.SaveChanges();
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

                    AtleticaJogoModel atleticaJogo = new AtleticaJogoModel
                    {
                        AtleticaId = amj.AtleticaModalidade.AtleticaId,
                        Nome = amj.AtleticaModalidade.Atletica.Nome,
                        Pontos = 0
                    };

                    TimeEscalado time = amj.Jogo.TimeEscalados.SingleOrDefault(te => te.AtleticaId == atleticaJogo.AtleticaId);

                    if (time != null)
                    {
                        foreach (AtletaAtleticaModalidadeTimeEscalado atletaAtleticaModalidadeTimeEscalado in time.AtletaAtleticaModalidadeTimeEscalados)
                        {
                            if (amj.AtleticaModalidade.AtleticaId == atleticaId)
                            {
                                AtletaJogoModel atletaJogo = new AtletaJogoModel();
                                jogoRes.Atletas.Add(atletaJogo.Transform(atletaAtleticaModalidadeTimeEscalado));
                            }
                            atleticaJogo.Pontos += atletaAtleticaModalidadeTimeEscalado.Pontos;
                        }
                    }

                    jogoRes.JogoId = amj.Jogo.JogoId;
                    jogoRes.DataHora = amj.Jogo.DataHora;
                    jogoRes.Atleticas.Add(atleticaJogo);
                }
            }

            foreach (JogoResponseModels jogoRes in jogosResponse.ToList())
                if (!jogoRes.Atleticas.Any(a => a.AtleticaId == atleticaId))
                    jogosResponse.Remove(jogoRes);

            return jogosResponse;
        }
    }
}
