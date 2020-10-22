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
            _context.Publicacoes.Add(publicacao);
            _context.SaveChanges();

            return new HttpRes(200, publicacao);
        }

        public HttpRes Deletar(int id)
        {
            var publicacao = _context.Publicacoes.Find(id);
            if (publicacao == null)
            {
                return new HttpRes(404, "Não existe nenhum publicação com este id");
            }
            // Remove a imagem da publicação também
            Imagem img = new Imagem { ImagemId = publicacao.ImagemId };
            _context.Imagens.Attach(img);
            _context.Imagens.Remove(img);

            _context.Publicacoes.Remove(publicacao);
            _context.SaveChanges();

            return new HttpRes(204);
        }

        public bool existePublicacao(int id)
        {
            return _context.Publicacoes.Any(p => p.PublicacaoId == id);
        }
    }
}
