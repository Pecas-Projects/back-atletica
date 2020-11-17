﻿using Back_Atletica.Repository;
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
        public HttpRes UploadImagemProduto(IFormFile Imagem, int produtoId, int userId)
        {
            return _RepositorioImagem.UploadImagemProduto(Imagem, produtoId, userId);
        }
    }
}
