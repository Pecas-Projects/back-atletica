using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository.Implementação
{
    public class AtleticaRepositoryImpl : IAtleticaRepository
    {
        AtleticaContext _context;

        public AtleticaRepositoryImpl(AtleticaContext context)
        {
            _context = context;
        }

        public HttpRes Atualizar(int id, Atletica atletica)
        {
            if (id != atletica.AtleticaId)
            {
                return new HttpRes(400, "O id passado não é o mesmo do objeto em questão");
            }

            _context.Entry(atletica).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!existeAtletica(id))
                {
                    return new HttpRes(404, "Não existe nenhum atlética com este id");
                }
                else
                {
                    throw;
                }
            }

            return new HttpRes(200, atletica);
        }

        public HttpRes BuscaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscaPorInstituicao(Faculdade faculdade)
        {
            throw new NotImplementedException();
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

        public HttpRes Criar(Atletica atletica)
        {
            _context.Atleticas.Add(atletica);
            _context.SaveChanges();

            return new HttpRes(200, atletica);
        }

        public HttpRes Deletar(int id)
        {
            var atletica = _context.Atleticas.Find(id);
            if (atletica == null)
            {
                return new HttpRes(404, "Não existe nenhum atletica com este id");
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
