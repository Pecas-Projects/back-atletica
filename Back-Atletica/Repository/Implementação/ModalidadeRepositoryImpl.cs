using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Back_Atletica.Utils.ResponseModels.AtleticaModalidadeResponseModels;
using static Back_Atletica.Utils.ResponseModels.ModalidadeResponseModels;

namespace Back_Atletica.Repository.Implementação
{
    public class ModalidadeRepositoryImpl : IModalidadeRepository
    {
        AtleticaContext _context;

        public ModalidadeRepositoryImpl(AtleticaContext context)
        {
            _context = context;
        }

        public HttpRes Criar(Modalidade modalidade)
        {
            try
            {
                _context.Modalidades.Add(modalidade);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);

                return new HttpRes(400, ex.InnerException.Message);
            }

            return new HttpRes(200, modalidade);
        }

        public HttpRes CriarAtleticaModalidade(AtleticaModalidade modalidade)
        {
            try
            {
                _context.AtleticaModalidades.Add(modalidade);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);

                return new HttpRes(400, ex.InnerException.Message);
            }

            return new HttpRes(200, modalidade);
        }

        public HttpRes Deletar(int id)
        {
            try
            {
                var modalidade = _context.Modalidades.Find(id);
                if (modalidade == null)
                {
                    return new HttpRes(404, "Não existe nenhum modalidade com este id");
                }

                _context.Modalidades.Remove(modalidade);
                _context.SaveChanges();

                return new HttpRes(204);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }

        }

        public HttpRes ExcluiModalidadeAtletica(int atleticaModalidadeId)
        {
            try
            {
                AtleticaModalidade modalidade = _context.AtleticaModalidades.SingleOrDefault(a => a.AtleticaModalidadeId == atleticaModalidadeId);

                if (modalidade == null)
                {
                    return new HttpRes(404, "Modalidade não encontrada.");
                }

                AtleticaModalidade desativada = modalidade;
                desativada.Ativo = false;

                _context.Entry(modalidade).CurrentValues.SetValues(desativada);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }

            return new HttpRes(204);
        }

        public HttpRes BuscarPorTodos()
        {
            return new HttpRes(200, _context.Modalidades.ToList());
        }

        public HttpRes BuscarTodosNaAtletica(int atleticaId)
        {

            List<AtleticaModalidade> atleticaModalidade = _context.AtleticaModalidades
                .Include(am => am.Modalidade)
                .Include(am => am.Imagem)
                .Include(am => am.AgendaTreinos)
                .Include(am => am.Membro).ThenInclude(a => a.Pessoa)
                .Where(am => am.AtleticaId == atleticaId && am.Ativo == true)
                .ToList();

            ModalidadesAtletica atleticaModalidades = new ModalidadesAtletica();

            return new HttpRes(200, atleticaModalidades.Transform(atleticaModalidade));
        }

        public HttpRes BuscarPorId(int id)
        {
            var modalidade = _context.Modalidades.Find(id);
            if (modalidade == null)
            {
                return new HttpRes(404, "Não existe nenhuma modalidade com este id");
            }
            return new HttpRes(200, modalidade);
        }

        public HttpRes AtualizaModalidadeAtletica(int atleticaModalidadeId, AtleticaModalidade modalidade)
        {
            if (modalidade == null) return new HttpRes(400, "Verifique os dados enviados");

            try
            {
                modalidade.AtleticaModalidadeId = atleticaModalidadeId;

                AtleticaModalidade modalidadeAtletica = _context.AtleticaModalidades
                    .Include(am => am.AgendaTreinos)
                    .SingleOrDefault(m => m.AtleticaModalidadeId == atleticaModalidadeId);

                if (modalidadeAtletica == null)
                    return new HttpRes(404, "Modalidade ou atlética não encontrada!");

                modalidade.Ativo = modalidadeAtletica.Ativo;
                modalidade.AtleticaId = modalidadeAtletica.AtleticaId;
                modalidade.PosicaoRanking = modalidadeAtletica.PosicaoRanking;

                _context.Entry(modalidadeAtletica).CurrentValues.SetValues(modalidade);

                if (modalidadeAtletica.AgendaTreinos != null)
                    _context.AgendaTreinos.RemoveRange(modalidadeAtletica.AgendaTreinos);

                if (modalidade.AgendaTreinos != null)
                    foreach (AgendaTreino treino in modalidade.AgendaTreinos)
                    {
                        treino.AtleticaModalidadeId = modalidade.AtleticaModalidadeId;
                        _context.AgendaTreinos.Add(treino);
                    }

                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }

            return new HttpRes(200, modalidade);
        }

        public bool existeModalidade(int id)
        {
            return _context.Modalidades.Any(a => a.ModalidadeId == id);
        }

        public HttpRes BuscarRanking(int modalidadeId)
        {
            List<AtleticaModalidadeResponse> amResponses = new List<AtleticaModalidadeResponse>();
            List<AtleticaModalidade> atleticaModalidades =
                _context.AtleticaModalidades
                .Include(am => am.Atletica).ThenInclude(a => a.ImagemAtleticas).ThenInclude(i => i.Imagem)
                .Include(am => am.Atletica).ThenInclude(a => a.Campus)
                .ThenInclude(c => c.Faculdade)
                .Where(am => am.ModalidadeId == modalidadeId)
                .ToList();

            foreach (AtleticaModalidade am in atleticaModalidades)
            {
                AtleticaModalidadeResponse amr = new AtleticaModalidadeResponse();
                amr = amr.Transform(am);

                amr.NumeroJogos = _context.AtleticaModalidadeJogos
                    .Where(amj => amj.AtleticaModalidadeId == amr.AtleticaModalidadeId).Count();

                amResponses.Add(amr);
            }

            amResponses = amResponses.OrderBy(amR => amR.PosicaoRanking).ToList();

            return new HttpRes(200, amResponses);
        }
    }
}
