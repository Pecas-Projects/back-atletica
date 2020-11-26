using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_Atletica.Business;
using Back_Atletica.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back_Atletica.Controllers
{
    [ApiController]
    public class FaculdadeController : ControllerBase
    {
        private IFaculdadeBusiness _FaculdadeBusiness;

        public FaculdadeController(IFaculdadeBusiness faculdadeBusiness)
        {
            _FaculdadeBusiness = faculdadeBusiness;
        }

        [Route("api/Faculdades")]
        [HttpGet]
        public IActionResult BuscarTodas()
        {
            var resultado = _FaculdadeBusiness.BuscarTodas();
            return resultado.HttpResponse();
        }

    }
}
