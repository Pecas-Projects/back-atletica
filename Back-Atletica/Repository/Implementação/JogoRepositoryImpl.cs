using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public HttpRes BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscarPorModalidade(int modalidadeId, long userId)
        {
            throw new NotImplementedException();
        }

        public HttpRes Deletar(int id)
        {
            var jogo = _context.Jogos.SingleOrDefault(a => a.JogoId == id);
            if (jogo == null)
            {
                return new HttpRes(404, "Jogo não encontrado");
            }

            _context.Jogos.Remove(jogo);
            _context.SaveChanges();

            return new HttpRes(204);
        }

        public bool existeJogo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
