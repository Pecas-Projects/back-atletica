using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public HttpRes BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public HttpRes Criar(Atletica atletica)
        {
            throw new NotImplementedException();
        }

        public HttpRes Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public bool existeAtletica(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
