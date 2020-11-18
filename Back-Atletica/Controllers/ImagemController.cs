using Back_Atletica.Business;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Controllers
{
    public class ImagemController : ControllerBase
    {

        IImagemBusiness _ImagemBusiness;
        public ImagemController(IImagemBusiness img)
        {
            _ImagemBusiness = img;
        }

        [Authorize]
        [Route("api/Imagem/Upload")]
        [HttpPost]
        public IActionResult UploadImagemProduto([FromForm] IFormFile value)
        {
            HttpRes result = _ImagemBusiness.Upload(value);

            return result.HttpResponse();
        }

        [Authorize]
        [Route("api/Image/Delete/{imagemId}")]
        [HttpPost]
        public IActionResult Delete(int imagemId)
        {
            HttpRes result = _ImagemBusiness.Delete(imagemId);

            return result.HttpResponse();
        }

    }
}
