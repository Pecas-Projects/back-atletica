using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using GeradorGrafosCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository.Implementação
{
    public class AtletaRepositpryImpl : IAtletaRepository
    {
        readonly AtleticaContext _context;

        public AtletaRepositpryImpl(AtleticaContext context)
        {
            _context = context;
        }

        public HttpRes Atualizar(int id, Atleta atleta)
        {
            if (atleta == null)
            {
                return new HttpRes(400, "Verifique os dados enviados");
            }

            try
            {
                Atleta atletaDate = _context.Atletas.SingleOrDefault(a => a.AtletaId == id);

                if (atletaDate == null) return new HttpRes(404, "Atleta não encontrado");

                _context.Entry(atletaDate).CurrentValues.SetValues(atleta);

                _context.SaveChanges();

                return new HttpRes(200, atleta);
            }

            catch (Exception ex)
            {

                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public HttpRes BuscaAtivos(int atleticaID)
        {
            Atletica atletica = new Atletica();

            atletica = _context.Atleticas.Find(atleticaID);

            if (atletica == null) return new HttpRes(404, "Atletica não encontrada");

            var atletas = new List<Pessoa>();

            atletas = _context.Pessoas.Where(a => a.AtleticaId == atleticaID && (a.Tipo == "A" || a.Tipo == "AM") && a.Atleta.Ativo == true).ToList();

            return new HttpRes(200, atletas);

        }

        public HttpRes BuscaPorID(int atletaID)
        {

            Atleta atleta = _context.Atletas.Find(atletaID);

            if (atleta == null) return new HttpRes(404, "atleta não encontrado");

            return new HttpRes(200, atleta);
        }

        public HttpRes BuscaPorModalidade(int atleticaModalidadeId)
        {

            var query = from aam in _context.AtletaAtleticaModalidades
                        join
                        a in _context.Atletas on aam.AtletaId equals a.AtletaId
                        join
                        p in _context.Pessoas on a.PessoaId equals p.PessoaId
                        where aam.AtleticaModalidadeId == atleticaModalidadeId && aam.Ativo

                        select new
                        {
                            aam.AtletaAtleticaModalidadeId,
                            aam.AtleticaModalidadeId,
                            a.AtletaId,
                            p.PessoaId,
                            p.Nome,
                            p.Sobrenome
                        };

            return new HttpRes(200, query);

        }

        public HttpRes BuscaPorJogo(int JogoId)
        {

            TimeEscalado timeEscalado = _context.TimeEscalados.SingleOrDefault(t => t.JogoId == JogoId);

            if (timeEscalado == null) return new HttpRes(404, "Jogo não encontrado");

            List<AtletaAtleticaModalidadeTimeEscalado> _atletaAtleticaModalidadeTimeEscalados = _context.AtletaAtleticaModalidadeTimesEscalados
                .Where(t => t.TimeEscaladoId == timeEscalado.TimeEscaladoId).ToList();

            var query = from atletaAtleticaModalidadeTimeEscalado in _atletaAtleticaModalidadeTimeEscalados
                        join
                   atletaAtleticaModalidade in _context.AtletaAtleticaModalidades on atletaAtleticaModalidadeTimeEscalado.AtletaAtleticaModalidadeId equals atletaAtleticaModalidade.AtletaAtleticaModalidadeId
                        join
                   a in _context.Atletas on atletaAtleticaModalidade.AtletaId equals a.AtletaId
                        join
                   p in _context.Pessoas on a.PessoaId equals p.PessoaId

                        select new { p };

            return new HttpRes(200, query);

        }

        public HttpRes BuscarTodos(int atleticaID)
        {
            var atletas = new List<Pessoa>();

            Atletica atletica = _context.Atleticas.Find(atleticaID);

            if (atletica == null) return new HttpRes(404, "Atlética não encontrada");

            atletas = _context.Pessoas.Where(a => a.AtleticaId == atleticaID && (a.Tipo == "A" || a.Tipo == "AM")).ToList();

            return new HttpRes(200, atletas);
        }

        public HttpRes CriarAtleta(Atleta atleta)
        {
            try
            {
                atleta.Ativo = true;
                _context.Atletas.Add(atleta);
                _context.SaveChanges();

                return new HttpRes(200, atleta);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public HttpRes Deletar(int id)
        {
            try
            {
                Atleta atleta = _context.Atletas.SingleOrDefault(a => a.AtletaId == id);
                if (!ExisteAtleta(id))
                {
                    return new HttpRes(404, "Atleta não encontrado");
                }

                _context.Atletas.Remove(atleta);
                _context.SaveChanges();

                return new HttpRes(204);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public bool ExisteAtleta(int atletaID)
        {
            bool existe = false;
            existe = _context.Atletas.Any(a => a.AtletaId == atletaID);

            return existe;
        }

        public HttpRes AdicionarAtletaModalidade(int atletaId, int atleticaModalidadeId)
        {
            try
            {
                AtletaAtleticaModalidade atletaAtleticaModalidade = _context.AtletaAtleticaModalidades
                    .SingleOrDefault(atletaAtleticaModalidade => atletaAtleticaModalidade.AtletaId == atletaId && atletaAtleticaModalidade.AtleticaModalidadeId == atleticaModalidadeId);

                if (atletaAtleticaModalidade == null)
                {
                    atletaAtleticaModalidade = new AtletaAtleticaModalidade
                    {
                        AtletaId = atletaId,
                        AtleticaModalidadeId = atleticaModalidadeId
                    };
                    _context.AtletaAtleticaModalidades.Add(atletaAtleticaModalidade);
                }
                else if (atletaAtleticaModalidade.Ativo)
                    return new HttpRes(404, "Este atleta já foi adicionado a esta modalidade");
                else if (!atletaAtleticaModalidade.Ativo)
                {
                    atletaAtleticaModalidade.Ativo = true;
                    _context.Entry(atletaAtleticaModalidade).CurrentValues.SetValues(atletaAtleticaModalidade);
                }

                _context.SaveChanges();

                return new HttpRes(200, atletaAtleticaModalidade);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public HttpRes RemoverAtletaModalidade(int atletaAtleticaModalidadeId)
        {
            try
            {
                AtletaAtleticaModalidade atletaAtleticaModalidade = _context.AtletaAtleticaModalidades
                    .SingleOrDefault(atletaAtleticaModalidade => atletaAtleticaModalidade.AtletaAtleticaModalidadeId == atletaAtleticaModalidadeId);

                if (atletaAtleticaModalidade == null) return new HttpRes(404, "AtletaAtleticaModalidade não encontrada");

                atletaAtleticaModalidade.Ativo = false;
                _context.Entry(atletaAtleticaModalidade).CurrentValues.SetValues(atletaAtleticaModalidade);
                _context.SaveChanges();

                return new HttpRes(204);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public HttpRes BuscarForaModalidade(int atleticaId, int modalidadeId)
        {
            var atletasModalidade = from aam in _context.AtletaAtleticaModalidades
                                    join
                                    a in _context.Atletas on aam.AtletaId equals a.AtletaId
                                    join
                                    am in _context.AtleticaModalidades on aam.AtleticaModalidadeId equals am.AtleticaModalidadeId
                                    where am.AtleticaId == atleticaId && am.ModalidadeId == modalidadeId && am.Ativo && aam.Ativo

                                    select new
                                    {
                                        a.AtletaId
                                    };

            List<int> atletasIds = new List<int>();

            foreach (var atletaModalidade in atletasModalidade)
                atletasIds.Add(atletaModalidade.AtletaId);

            var atletasFora = _context.Atletas
                .Include(a => a.Pessoa)
                .Where(a => !atletasIds.Contains(a.AtletaId) && a.Pessoa.AtleticaId == atleticaId)
                .Select(a => new { a.AtletaId, a.PessoaId, a.Pessoa.Nome, a.Pessoa.Sobrenome })
                .Distinct()
                .ToList();

            return new HttpRes(200, atletasFora);
        }

        public HttpRes AdicionarAtletaTime(int timeId, List<AtletaAtleticaModalidadeTimeEscalado> atletaAtleticaModalidadeTimeEscalados)
        {
            try
            {
                TimeEscalado time = _context.TimeEscalados
                    .Include(te => te.AtletaAtleticaModalidadeTimeEscalados)
                    .SingleOrDefault(te => te.TimeEscaladoId == timeId);

                foreach (AtletaAtleticaModalidadeTimeEscalado atletaTime in atletaAtleticaModalidadeTimeEscalados)
                {
                    atletaTime.TimeEscaladoId = timeId;
                    _context.AtletaAtleticaModalidadeTimesEscalados.Add(atletaTime);
                }

                _context.SaveChanges();

                List<AtletaAtleticaModalidadeTimeEscalado> atletasTime = _context.AtletaAtleticaModalidadeTimesEscalados
                    .Where(amt => amt.TimeEscaladoId == time.TimeEscaladoId)
                    .ToList();

                foreach (AtletaAtleticaModalidadeTimeEscalado a in atletasTime)
                    time.PontuacaoJogo += (int)a.Pontos;

                _context.SaveChanges();
                time.RegistrouEscalacao = true;
                _context.SaveChanges();

                Jogo j = _context.Jogos.SingleOrDefault(j => j.JogoId == time.JogoId);

                 if (j.Finalizado)
                {
                    List<AtletaAtleticaModalidade> aam =
                        _context.AtletaAtleticaModalidades
                        .Include(aam => aam.AtleticaModalidade)
                        .Where(aam => aam.AtletaAtleticaModalidadeId == time.AtletaAtleticaModalidadeTimeEscalados[0].AtletaAtleticaModalidadeId)
                        .ToList();

                    this.CalculaRanking(aam[0].AtleticaModalidade.ModalidadeId);
                }

                return new HttpRes(204);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public HttpRes AtualizarAtletaTime(AtletaAtleticaModalidadeTimeEscalado atletaAtleticaModalidadeTimeEscalado)
        {
            if (atletaAtleticaModalidadeTimeEscalado == null)
            {
                return new HttpRes(400, "Verifique os dados enviados");
            }
            try
            {
                AtletaAtleticaModalidadeTimeEscalado atletaAtleticaModalidadeTimeEscaladoData = _context.AtletaAtleticaModalidadeTimesEscalados
                    .SingleOrDefault(a => a.AtletaAtleticaModalidadeTimeEscaladoId == atletaAtleticaModalidadeTimeEscalado.AtletaAtleticaModalidadeTimeEscaladoId);

                if (atletaAtleticaModalidadeTimeEscaladoData == null) return new HttpRes(404, "AtletaAtleticaModalidadeTimeEscalado não encontrado");


                atletaAtleticaModalidadeTimeEscalado.AtletaAtleticaModalidadeId = atletaAtleticaModalidadeTimeEscaladoData.AtletaAtleticaModalidadeId;
                atletaAtleticaModalidadeTimeEscalado.TimeEscaladoId = atletaAtleticaModalidadeTimeEscaladoData.TimeEscaladoId;

                _context.Entry(atletaAtleticaModalidadeTimeEscaladoData).CurrentValues.SetValues(atletaAtleticaModalidadeTimeEscalado);
                _context.SaveChanges();

                return new HttpRes(200, atletaAtleticaModalidadeTimeEscalado);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public HttpRes RemoverAtletaTime(int atletaAtleticaModalidadeTimeEscaladoId)
        {
            AtletaAtleticaModalidadeTimeEscalado atletaAtleticaModalidadeTimeEscalado = _context.AtletaAtleticaModalidadeTimesEscalados
                .SingleOrDefault(a => a.AtletaAtleticaModalidadeTimeEscaladoId == atletaAtleticaModalidadeTimeEscaladoId);

            if (atletaAtleticaModalidadeTimeEscalado == null)
            {
                return new HttpRes(404, "AtletaAtleticaModalidadeTimeEscalado não encontrado");
            }
            try
            {
                _context.AtletaAtleticaModalidadeTimesEscalados.Remove(atletaAtleticaModalidadeTimeEscalado);
                _context.SaveChanges();

                return new HttpRes(204);
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
            int cont = 0;
            List<double> posicoes = new List<double>();
            List<int> idJogos = new List<int>();
            List<AtleticaModalidade> atleticas = _context.AtleticaModalidades.Where(am => am.ModalidadeId == modalidadeId).ToList();

            //List<AtleticaModalidadeJogo>AMJ = _context.AtleticaModalidadeJogos.Where(a => a.)

            var jogos = from amj in _context.AtleticaModalidadeJogos
                        join
                        am in _context.AtleticaModalidades on amj.AtleticaModalidadeId equals am.AtleticaModalidadeId
                        join 
                        j in _context.Jogos on amj.JogoId equals j.JogoId
                        join
                        jc in _context.JogoCategorias on j.JogoCategoriaId equals jc.JogoCategoriaId
                        where am.ModalidadeId == modalidadeId && jc.Nome != "Treino" && j.Finalizado == true
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
                idJogos.Add(jogo.JogoId);
            }

            idJogos = idJogos.Distinct().ToList();

            foreach (int idJogo in idJogos)
            {

                List<AtleticaModalidadeJogo> participantes = _context.AtleticaModalidadeJogos.Where(amj => amj.JogoId == idJogo).ToList();
                List<AtleticaModalidadeJogo> vencedores = new List<AtleticaModalidadeJogo>();

                foreach (AtleticaModalidadeJogo participante in participantes)
                {
                    if (participante.Vencedor == true)
                    {
                        vencedores.Add(participante);
                    }
                }

                foreach (var amj in participantes)
                {
                    if (amj.Vencedor == false)
                    {
                        foreach (var vencedor in vencedores)
                        {
                            Arco a = new Arco();
                            a.saida = grafo.ProcuraVertice(((AtleticaModalidadeJogo)amj).AtleticaModalidadeId);
                            a.entrada = grafo.ProcuraVertice(vencedor.AtleticaModalidadeId);
                            grafo.AdicionarArco(a);
                        }
                    }
                }
            }

            grafo.PageRank();
            cont = 0;

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
    }
}
