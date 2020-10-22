using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository.Implementação
{
    public class PublicacaoRepositoryImpl : IPublicacaoRepository
    {
        AtleticaContext _context;

        public PublicacaoRepositoryImpl(AtleticaContext context)
        {
            _context = context;
        }

        public HttpRes Atualizar(int id, Publicacao publicacao)
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscarPorAtletica(int atleticaId)
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public HttpRes Criar(Publicacao publicacao)
        {
            throw new NotImplementedException();
        }

        public HttpRes Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public bool existePublicacao(int id)
        {
            return _context.Publicacoes.Any(p => p.PublicacaoId == id);
        }
    }
}
