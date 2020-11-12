using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
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

        public HttpRes Atualizar(int id, Atletica atletica, List<int> CursosId)
        {
            if (atletica == null) return new HttpRes(400, "Verifique os dados enviados");

            try
            {
                Atletica atleticaDados = _context.Atleticas
                    .Include(a => a.Campus)
                    .ThenInclude(a => a.Faculdade)
                    .SingleOrDefault(a => a.AtleticaId == id);

                if(atleticaDados == null) return new HttpRes(404, "Atletica não encontrada");

                List<AtleticaCurso> atleticaCursoDado = _context.AtleticaCursos.Where(a => a.AtleticaId == id).ToList();

                if (atleticaCursoDado.Count == 0) return new HttpRes(404, "Atletica não encontrada");

                foreach (AtleticaCurso a in atleticaCursoDado)
                {
                    _context.Remove(a);
                }

                atletica.AtleticaId = atleticaDados.AtleticaId;
                atletica.PIN = atleticaDados.PIN;
                atletica.Senha = atleticaDados.Senha;
                atletica.CampusId = atleticaDados.CampusId;
                atletica.Campus.FaculdadeId = atletica.Campus.FaculdadeId;

                _context.Entry(atleticaDados).CurrentValues.SetValues(atletica);

                
                foreach (int a in CursosId)
                {
                    AtleticaCurso atleticaCurso = new AtleticaCurso();
                    atleticaCurso.AtleticaId = id;
                    atleticaCurso.CursoId = a;
                    _context.Add(atleticaCurso);
                }

                _context.SaveChanges();

                return new HttpRes(200, atletica);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }

        }

        public HttpRes BuscaPorId(int id)
        {
            Atletica atletica = _context.Atleticas
                .Include(a => a.Campus).ThenInclude(a => a.Faculdade)
                .Include(a => a.ImagemAtleticas).ThenInclude(a => a.Imagem)
                .Include(a => a.Pessoas).ThenInclude(a => a.Membro).ThenInclude(a => a.Imagem)
                .SingleOrDefault(a => a.AtleticaId == id);

            if (atletica == null) return new HttpRes(404, "Não existe nenhuma atlética com este id");

            if(atletica.Pessoas != null)
            {
                List<Pessoa> pessoas = new List<Pessoa>();

                foreach (Pessoa p in atletica.Pessoas)
                {
                    if (p.Tipo != "A") pessoas.Add(p);
                }
                atletica.Pessoas = pessoas;

            }

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
            return new HttpRes(200, _context.Atleticas.ToList());
        }
 
        public HttpRes Deletar(int id)
        {
            var atletica = _context.Atleticas.SingleOrDefault(a => a.AtleticaId == id);
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
    }
}
