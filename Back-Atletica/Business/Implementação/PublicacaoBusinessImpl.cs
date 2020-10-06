using Back_Atletica.Models;
using Back_Atletica.Repository;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business.Implementação
{
    public class PublicacaoBusinessImpl : IPublicacaoBusiness
    {
        private IPublicacaoRepository _PublicacaoRepository;

        public PublicacaoBusinessImpl(IPublicacaoRepository publicacaoRepository)
        {
            _PublicacaoRepository = publicacaoRepository;
        }

        public HttpRes Atualizar(int id, Publicacao publicacao)
        {
            return _PublicacaoRepository.Atualizar(id, publicacao);
        }

        public HttpRes BuscarPorAtletica(int atleticaId)
        {
            return _PublicacaoRepository.BuscarPorAtletica(atleticaId);
        }

        public HttpRes BuscarPorId(int id)
        {
            return _PublicacaoRepository.BuscarPorId(id);
        }

        public HttpRes Criar(Publicacao publicacao)
        {
            return _PublicacaoRepository.Criar(publicacao);
        }

        public HttpRes Deletar(int id)
        {
            return _PublicacaoRepository.Deletar(id);
        }
    }
}
