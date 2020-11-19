using Back_Atletica.Data;
using Back_Atletica.Utils;
using Microsoft.AspNetCore.Http;
using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Back_Atletica.Repository.Implementação
{
    public class ImagemRepositoryImpl : IImagemRepository
    {
        readonly AtleticaContext _context;
        public ImagemRepositoryImpl(AtleticaContext context)
        {
            _context = context;
        }

        public HttpRes Delete(int imagemId)
        {
            Imagem imagem = _context.Imagens.SingleOrDefault(i => i.ImagemId == imagemId);

            if (imagem == null) return new HttpRes(404, "Imagem não encontrada");

            Account account = new Account(Env.CLOUD_NAME, Env.API_KEY, Env.API_SECRET);
            Cloudinary cloudinary = new Cloudinary(account);

            var deletionParams = new DeletionParams(imagem.PublicId);
            var deletionResult = cloudinary.Destroy(deletionParams);

            if (deletionResult.Result.Equals("ok")) return new HttpRes(204);

            else return new HttpRes(400, "Erro ao apagar a imagem");

        }

        public HttpRes Upload(IFormFile Imagem)
        {
            Account account = new Account(Env.CLOUD_NAME, Env.API_KEY, Env.API_SECRET);
            Cloudinary cloudinary = new Cloudinary(account);

            Imagem img = new Imagem();
            try
            {
                ImageUploadResult uploadResult;

                if (Imagem.Length > 0)
                {
                    using (var stream = Imagem.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(Imagem.Name, stream),
                            Transformation = new Transformation()
                            .Width(800),
                        };

                        uploadResult = cloudinary.Upload(uploadParams);
                        img.Extensao = uploadResult.Format;
                        img.Path = uploadResult.Url.ToString();
                        img.PublicId = uploadResult.PublicId;

                    }

                }

                _context.Add(img);

                _context.SaveChanges();

                return new HttpRes(201, img);
            }
            catch(Exception ex)
            {
                var deletionParams = new DeletionParams(img.PublicId);
                var deletionResult = cloudinary.Destroy(deletionParams);

                if (deletionResult.Result.Equals("ok"))
                {
                    if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                    return new HttpRes(400, ex.InnerException.Message);
                }
                else
                {
                    return new HttpRes(400, "Erro ao apagar a imagem");
                }

            }

        }
    }
}
