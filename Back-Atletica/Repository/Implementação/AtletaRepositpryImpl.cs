﻿using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
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

            var query = from atletaAtleticaModalidade in atletaAtleticaModalidades
                        join
                        a in _context.Atletas on atletaAtleticaModalidade.AtletaId equals a.AtletaId
                        join
                        p in _context.Pessoas on a.PessoaId equals p.PessoaId

                        select new
                        {
                            atletaAtleticaModalidade.AtletaAtleticaModalidadeId,
                            atletaAtleticaModalidade.AtleticaModalidadeId,
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

            var query = (from am in _context.AtleticaModalidades
                         join
                         atletaAtleticaModalidade in _context.AtletaAtleticaModalidades on am.AtleticaModalidadeId equals atletaAtleticaModalidade.AtleticaModalidadeId
                         join
                         a in _context.Atletas on atletaAtleticaModalidade.AtletaId equals a.AtletaId
                         join
                         p in _context.Pessoas on a.PessoaId equals p.PessoaId
                         where am.AtleticaId == atleticaId && (am.ModalidadeId != modalidadeId || (am.ModalidadeId == modalidadeId && atletaAtleticaModalidade.Ativo == false))
                         select new
                         {
                             a.AtletaId,
                             p.Nome
                         }).Distinct();

            return new HttpRes(200, query);
        }

        public HttpRes AdicionarAtletaTime(int atleticaId, int jogoId, AtletaAtleticaModalidadeTimeEscalado atletaAtleticaModalidadeTimeEscalado)
        {
            try
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

                atletaAtleticaModalidadeTimeEscalado.TimeEscaladoId = time.TimeEscaladoId;
                _context.AtletaAtleticaModalidadeTimesEscalados.Add(atletaAtleticaModalidadeTimeEscalado);
                _context.SaveChanges();

                return new HttpRes(200, atletaAtleticaModalidadeTimeEscalado);
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
    }
}
