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
    public class AtleticaController : ControllerBase
    {
        private IAtleticaBusiness _AtleticaBusiness;

        public AtleticaController(IAtleticaBusiness atleticaBusiness)
        {
            _AtleticaBusiness = atleticaBusiness;
        }

        [Route("api/Atletica")]
        [HttpGet]
        public IActionResult Get()
        {
            return BadRequest();
        }

        [Route("api/Atletica/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            return BadRequest();
        }

        [Route("api/Atletica")]
        [HttpPost]
        public IActionResult Create([FromBody] Atletica value)
        {
            var result = _AtleticaBusiness.Create(value);

            return result.HttpResponse();
        }

        [Route("api/Atletica/{id}")]
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Atletica value)
        {
            return BadRequest();
        }

        [Route("api/Atletica/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return BadRequest();
        }
    }
}
