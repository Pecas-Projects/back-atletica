using Back_Atletica.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils
{
    public class ImageUpload
    {
        public static Imagem UploadImage(IFormFile ImagemData)
        {
            Account account = new Account(Env.CLOUD_NAME, Env.API_KEY, Env.API_SECRET);
            Cloudinary cloudinary = new Cloudinary(account);

            Imagem imagem = new Imagem();
            imagem.Nome = ImagemData.FileName;

            try
            {

                ImageUploadResult uploadResult;

                if (ImagemData.Length > 0)
                {
                    using (var stream = ImagemData.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(ImagemData.Name, stream),
                            Transformation = new Transformation()
                            .Width(800),
                        };

                        uploadResult = cloudinary.Upload(uploadParams);
                        imagem.Extensao = uploadResult.Format;
                        imagem.Path = uploadResult.Url.ToString();

                    }

                }
            }
            catch
            {
                return null;
            }

            return imagem;
        }

        public void DeleteImagem(Imagem imagem)
        {
                Account account = new Account(Env.CLOUD_NAME, Env.API_KEY, Env.API_SECRET);
                Cloudinary cloudinary = new Cloudinary(account);
                // var deletionParams = new DeletionParams(imagem.PublicId);
                // var deletionResult = cloudinary.Destroy(deletionParams);


        }
    }
}
