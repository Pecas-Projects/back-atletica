using Back_Atletica.Repository;
using Back_Atletica.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business.Implementação
{
    public class ImageBusinessImpl : IImagemBusiness
    {
        private readonly IImagemRepository _RepositorioImagem;

        public ImageBusinessImpl(IImagemRepository repositorioImagem)
        {
            _RepositorioImagem = repositorioImagem;
        }
        public HttpRes Upload(IFormFile Imagem)
        {
            return _RepositorioImagem.Upload(Imagem);
        }
    }
}
