using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Back_Atletica.Business;
using Back_Atletica.Models;
using Microsoft.AspNetCore.Mvc;
using static Back_Atletica.Utils.RequestModels.AutenticacaoModel;
using Back_Atletica.Utils.RequestModels;
using Back_Atletica.Utils;

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

        [Route("api/Registro/Atletica")]
        [HttpPost]
        public IActionResult RegistroAtletica([FromBody] RegistroAtleticaModel value)
        {

            Atletica atletica = value.Transform();

            HttpRes result = _AutenticacaoBusiness.RegistrarAtletica(atletica);

            return result.HttpResponse();
        }

        [Route("api/Registro/Membro/{Atletica_Pin}")]
        [HttpPost]
        public IActionResult RegistroMembro([FromBody] RegistroMembroModel value, string Atletica_Pin)
        {
            Membro membro = value.Transform();

            Atletica atletica = new Atletica
            {
                PIN = Atletica_Pin
            };

            membro.Pessoa.Atletica = atletica;

            var result = _AutenticacaoBusiness.RegistrarMembro(membro);

            return result.HttpResponse();
        }

        [Route("api/Login/Atletica")]
        [HttpPost]
        public IActionResult LoginAtletica([FromBody] LoginAtleticaModel value)
        {
            Atletica data = value.Transform();

            var result = _AutenticacaoBusiness.LoginAtletica(data);

            return result.HttpResponse();
        }

        [Route("api/Login/Membro")]
        [HttpPost]
        public IActionResult LoginMembro([FromBody] LoginMembroModel value)
        {
            Membro data = value.Transform();

            var result = _AutenticacaoBusiness.LoginMembro(data);

            return result.HttpResponse();
        }

        [Route("api/ReseteSenha/Atletica")]
        [HttpPost]
        public IActionResult ResetarSenhaAtletica([FromBody] EmailModel email)
        {
            string data = email.Transform();
            var result = _AutenticacaoBusiness.ResetarSenhaAtletica(data);

            return result.HttpResponse();
        }

        [Authorize]
        [Route("api/MudancaSenha/Atletica")]
        [HttpPost]
        public IActionResult MudancaSenha([FromBody] SenhaResetarModel senha)
        {
            string data = senha.Transform();

            var id = HttpToken.GetUserId(HttpContext);

            if (HttpToken.GetTokenType(HttpContext) != "Reset") return BadRequest("Token Invalido");

            var result = _AutenticacaoBusiness.MudancaSenha((int)id, data);

            return result.HttpResponse();
        }

    }
}
