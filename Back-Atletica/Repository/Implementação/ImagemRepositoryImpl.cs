using Back_Atletica.Data;
using Back_Atletica.Utils;
using Microsoft.AspNetCore.Http;
using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository.Implementação
{
    public class ImagemRepositoryImpl : IImagemRepository
    {
        readonly AtleticaContext _context;
        public ImagemRepositoryImpl(AtleticaContext context)
        {
            _context = context;
        }

        public HttpRes UploadImagemProduto(IFormFile Imagem, int produtoId)
        {
            try
            {
                Imagem img = ImageUpload.UploadImage(Imagem);

                return new HttpRes(201, img);
            }
            catch(Exception ex)
            {
                if(ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }

        }
    }
}
