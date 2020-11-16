using Back_Atletica.Business;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [Route("api/Upload/Produto/{produtoId}")]
        [HttpPost]
        public IActionResult UploadImagemProduto([FromForm] IFormFile value, int produtoId)
        {
            HttpRes result = _ImagemBusiness.UploadImagemProduto(value, produtoId);

            return result.HttpResponse();
        }

    }
}
