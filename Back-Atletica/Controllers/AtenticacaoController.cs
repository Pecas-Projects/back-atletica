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
    public class AtenticacaoController : ControllerBase
    {
        IAutenticacaoBusiness _AutenticacaoBusiness;

        public AtenticacaoController(IAutenticacaoBusiness business)
        {
            _AutenticacaoBusiness = business;
        }

        [Route("api/Auth/Registro")]
        [HttpPost]
        public IActionResult Registro([FromBody] Atletica value)
        {
            var result = _AutenticacaoBusiness.Registrar(value);

            return result.HttpResponse();
        }

    }
}
