using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static Back_Atletica.Utils.ResponseModels.AtleticaResponseModels;

namespace Back_Atletica.Repository.Implementação
{
    public class AtleticaRepositoryImpl : IAtleticaRepository
    {
        AtleticaContext _context;

        public AtleticaRepositoryImpl(AtleticaContext context)
        {
            _context = context;
        }

        public HttpRes Atualizar(int id, Atletica atletica, List<int> CursosId, List<ImagemAtletica> ImagensIds)
        {
            if (atletica == null) return new HttpRes(400, "Verifique os dados enviados");

            try
            {
                Atletica atleticaDados = _context.Atleticas
                    .Include(a => a.Campus)
                    .ThenInclude(a => a.Faculdade)
                    .Include(i => i.ImagemAtleticas).ThenInclude(i => i.Imagem)
                    .Include(c => c.AtleticaCursos)
                    .SingleOrDefault(a => a.AtleticaId == id);

                if (atleticaDados == null) return new HttpRes(404, "Atletica não encontrada");

                List<AtleticaCurso> atleticaCursoDado = atleticaDados.AtleticaCursos.ToList();
                List<ImagemAtletica> imgAtletica = atleticaDados.ImagemAtleticas.ToList();

                RemoveRelacoesAntigas(atleticaCursoDado, imgAtletica);

                atletica.AtleticaId = atleticaDados.AtleticaId;
                atletica.PIN = atleticaDados.PIN;
                atletica.Senha = atleticaDados.Senha;
                atletica.CampusId = atleticaDados.CampusId;
                atletica.Campus.CampusId = atleticaDados.Campus.CampusId;
                atletica.Campus.FaculdadeId = atleticaDados.Campus.FaculdadeId;
                atletica.Campus.Faculdade.FaculdadeId = atleticaDados.Campus.Faculdade.FaculdadeId;

                _context.Entry(atleticaDados).CurrentValues.SetValues(atletica);
                _context.Entry(atleticaDados.Campus).CurrentValues.SetValues(atletica.Campus);
                _context.Entry(atleticaDados.Campus.Faculdade).CurrentValues.SetValues(atletica.Campus.Faculdade);

                CriacaoDeNovosRelacionamentos(CursosId, ImagensIds, id);

                _context.SaveChanges();

                return new HttpRes(200, atletica);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }

        }

        private void CriacaoDeNovosRelacionamentos(List<int> cursosId, List<ImagemAtletica> ImagemAtletica, int id)
        {
            foreach (int a in cursosId)
            {
                AtleticaCurso atleticaCurso = new AtleticaCurso();
                atleticaCurso.AtleticaId = id;
                atleticaCurso.CursoId = a;
                _context.Add(atleticaCurso);
            }

            foreach (ImagemAtletica i in ImagemAtletica)
            {
                ImagemAtletica img = new ImagemAtletica();
                img.Tipo = i.Tipo;
                img.AtleticaId = id;
                img.ImagemId = i.ImagemId;
                _context.Add(img);
            }
        }

        private void RemoveRelacoesAntigas(List<AtleticaCurso> atleticaCursoDado, List<ImagemAtletica> imgAtletica)
        {
            if (atleticaCursoDado.Count > 0)
                foreach (AtleticaCurso a in atleticaCursoDado) _context.Remove(a);

            if (imgAtletica.Count > 0)
            {
                Account account = new Account(Env.CLOUD_NAME, Env.API_KEY, Env.API_SECRET);
                Cloudinary cloudinary = new Cloudinary(account);
                foreach (ImagemAtletica i in imgAtletica)
                {
                    var deletionParams = new DeletionParams(i.Imagem.PublicId);
                    cloudinary.Destroy(deletionParams);
                    _context.Remove(i);
                }
            }
        }

        public HttpRes BuscaPorId(int id)
        {
            Atletica atletica = _context.Atleticas
                .Include(a => a.Campus)
                    .ThenInclude(a => a.Faculdade)
                .Include(a => a.ImagemAtleticas)
                    .ThenInclude(a => a.Imagem)
                .Include(a => a.Pessoas)
                    .ThenInclude(a => a.Membro)
                        .ThenInclude(a => a.Imagem)
                .Include(a => a.AtleticaCursos)
                    .ThenInclude(c => c.Curso)
                .SingleOrDefault(a => a.AtleticaId == id);

            if (atletica == null) return new HttpRes(404, "Não existe nenhuma atlética com este id");

            AtleticaPorId result = new AtleticaPorId();

            return new HttpRes(200, result.Transform(atletica));
        }

        public HttpRes BuscaPorInstituicao(int faculdadeId)
        {
            List<Atletica> atleticas = _context.Atleticas
                .Where(a => a.Campus.FaculdadeId.Equals(faculdadeId))
                .ToList();

            return new HttpRes(200, atleticas);
        }

        public HttpRes BuscaPorNome(string nome)
        {
            var atleticas = _context.Atleticas
                .Where(a => EF.Functions.Like(a.Nome.ToUpper(), "%" + nome.ToUpper() + "%"))
                .OrderBy(a => EF.Functions.Like(a.Nome.ToUpper(), nome.ToUpper() + "%") ? 1 :
                    EF.Functions.Like(a.Nome.ToUpper(), "%" + nome.ToUpper()) ? 3 : 2)
                .ToList();

            return new HttpRes(200, atleticas);
        }

        public HttpRes BuscarTodos()
        {
            return new HttpRes(200, _context.Atleticas.ToList().OrderBy(a => a.Nome));
        }

        public HttpRes Deletar(int atleticaId)
        {

            Atletica atletica = _context.Atleticas.SingleOrDefault(a => a.AtleticaId == atleticaId);

            if (atletica == null)
            {
                return new HttpRes(404, "Atletica não encontrada");
            }

            _context.Atleticas.Remove(atletica);
            _context.SaveChanges();

            return new HttpRes(204);
        }

        public bool existeAtletica(int id)
        {
            return _context.Atleticas.Any(a => a.AtleticaId == id);
        }

        public HttpRes RankingAtleticas(int modalidadeId, int alteticaId)
        {
            throw new NotImplementedException();
        }

        public HttpRes RemoverMembro(int membroId, int atleticaId)
        {
            try
            {
                bool exist = _context.Pessoas.Any(a => a.Membro.MembroId == membroId && a.AtleticaId == atleticaId);
                if (!exist) return new HttpRes(404, "Membro não encontrado");


            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }
            throw new NotImplementedException();
        }

        public HttpRes ResetPin(int atleticaId)
        {
            try
            {
                Atletica atleticaDado = _context.Atleticas.SingleOrDefault(a => a.AtleticaId == atleticaId);

                Atletica atletica = atleticaDado;
                atletica.PIN = new AtleticaPin().GerarPIN();

                _context.Entry(atleticaDado).CurrentValues.SetValues(atletica);
                _context.SaveChanges();

                return new HttpRes(200, atletica);

            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }

        }

        public HttpRes BuscaPorUsername(string username)
        {
            Atletica atletica = _context.Atleticas
               .Include(a => a.Campus)
                    .ThenInclude(a => a.Faculdade)
               .Include(a => a.ImagemAtleticas)
                    .ThenInclude(a => a.Imagem)
               .Include(a => a.Pessoas)
                    .ThenInclude(a => a.Membro)
                         .ThenInclude(a => a.Imagem)
              .Include(a => a.AtleticaCursos)
                    .ThenInclude(c => c.Curso)
               .SingleOrDefault(a => a.Username == username);

            if (atletica == null) return new HttpRes(404, "Não existe nenhuma atlética com este id");

            AtleticaPorId result = new AtleticaPorId();

            return new HttpRes(200, result.Transform(atletica));
        }

        public HttpRes VerificacaoUsername(string username)
        {
            bool exist = _context.Atleticas.Any(a => a.Username.Equals(username));

            if (exist) return new HttpRes(400, "Username ja esta em uso");
            return new HttpRes(204);
        }
    }
}
