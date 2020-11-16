using Back_Atletica.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository
{
    public interface IImagemRepository
    {
        HttpRes UploadImagemProduto(IFormFile Imagem, int produtoId);
    }
}
