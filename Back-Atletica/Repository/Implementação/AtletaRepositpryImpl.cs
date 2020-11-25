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

            List<AtletaAtleticaModalidade> atletaAtleticaModalidades = _context.AtletaAtleticaModalidades
                .Where(a => a.AtleticaModalidadeId == atleticaModalidadeId && a.Ativo)
                .ToList();

            var query = from aam in atletaAtleticaModalidades
                        join
                        a in _context.Atletas on aam.AtletaId equals a.AtletaId
                        join
                        p in _context.Pessoas on a.PessoaId equals p.PessoaId

                        select new
                        {
                            aam.AtletaAtleticaModalidadeId,
                            aam.AtleticaModalidadeId,
                            a.AtletaId,
                            p.PessoaId,
                            p.Nome
                        };

            return new HttpRes(200, query);

        }

        public HttpRes BuscaPorJogo(int JogoId)
        {

            TimeEscalado timeEscalado = _context.TimeEscalados.SingleOrDefault(t => t.JogoId == JogoId);

            if (timeEscalado == null) return new HttpRes(404, "Jogo não encontrado");

            List<AtletaAtleticaModalidadeTimeEscalado> _atletaAtleticaModalidadeTimeEscalados = _context.AtletaAtleticaModalidadeTimesEscalados
                .Where(t => t.TimeEscaladoId == timeEscalado.TimeEscaladoId).ToList();

            var query = from aamte in _atletaAtleticaModalidadeTimeEscalados
                        join
                   aam in _context.AtletaAtleticaModalidades on aamte.AtletaAtleticaModalidadeId equals aam.AtletaAtleticaModalidadeId
                        join
                   a in _context.Atletas on aam.AtletaId equals a.AtletaId
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
            atleta.Ativo = true;
            _context.Atletas.Add(atleta);
            _context.SaveChanges();

            return new HttpRes(200, atleta);
        }

        public HttpRes Deletar(int id)
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

        public bool ExisteAtleta(int atletaID)
        {
            bool existe = false;
            existe = _context.Atletas.Any(a => a.AtletaId == atletaID);

            return existe;
        }

        public HttpRes AdicionarAtletaModalidade(int atletaId, int atleticaModalidadeId)
        {
            AtletaAtleticaModalidade aam = _context.AtletaAtleticaModalidades
                .SingleOrDefault(aam => aam.AtletaId == atletaId && aam.AtleticaModalidadeId == atleticaModalidadeId);

            if (aam == null)
            {
                aam = new AtletaAtleticaModalidade
                {
                    AtletaId = atletaId,
                    AtleticaModalidadeId = atleticaModalidadeId
                };
                _context.AtletaAtleticaModalidades.Add(aam);
            }
            else if (aam.Ativo)
                return new HttpRes(404, "Este atleta já foi adicionado a esta modalidade");
            else if (!aam.Ativo)
            {
                aam.Ativo = true;
                _context.Entry(aam).CurrentValues.SetValues(aam);
            }

            _context.SaveChanges();

            return new HttpRes(200, aam);
        }

        public HttpRes RemoverAtletaModalidade(int atletaAtleticaModalidadeId)
        {
            try
            {
                AtletaAtleticaModalidade aam = _context.AtletaAtleticaModalidades
                    .SingleOrDefault(aam => aam.AtletaAtleticaModalidadeId == atletaAtleticaModalidadeId);

                if (aam == null) return new HttpRes(404, "AtletaAtleticaModalidade não encontrada");

                aam.Ativo = false;
                _context.Entry(aam).CurrentValues.SetValues(aam);
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

            var query = (from am in _context.AtleticaModalidades
                         join
                         aam in _context.AtletaAtleticaModalidades on am.AtleticaModalidadeId equals aam.AtleticaModalidadeId
                         join
                         a in _context.Atletas on aam.AtletaId equals a.AtletaId
                         join
                         p in _context.Pessoas on a.PessoaId equals p.PessoaId
                         where am.AtleticaId == atleticaId && (am.ModalidadeId != modalidadeId || (am.ModalidadeId == modalidadeId && aam.Ativo == false))
                         select new
                         {
                             a.AtletaId,
                             p.Nome
                         }).Distinct();

            return new HttpRes(200, query);
        }

        public HttpRes AdicionarAtletaTime(int atleticaId, int jogoId, AtletaAtleticaModalidadeTimeEscalado aamte)
        {
            TimeEscalado time = _context.TimeEscalados
                .SingleOrDefault(te => te.AtleticaId == atleticaId && te.JogoId == jogoId);

            if (time == null)
            {
                time = new TimeEscalado
                {
                    AtleticaId = atleticaId,
                    JogoId = jogoId
                };
                _context.TimeEscalados.Add(time);
                _context.SaveChanges();
            }

            aamte.TimeEscaladoId = time.TimeEscaladoId;
            _context.AtletaAtleticaModalidadeTimesEscalados.Add(aamte);
            _context.SaveChanges();

            //depois de cadastrar marca o bool registrouEscalacao em TimeEscalado como true
            //this.CalculaRanking() if o bool jogoFinalizado de jogo for igual a true
            //precisa passar como parâmetro a moalidade do jogo
            return new HttpRes(200, aamte);
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
                idJogos.Add(jogo.JogoId);
            }

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
