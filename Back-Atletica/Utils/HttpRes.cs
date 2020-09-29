using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils
{
    public class HttpRes : ControllerBase
    {
        public dynamic obj { get; set; }
        public int status { get; set; }
        public string msg { get; set; }

        public HttpRes(int status)
        {
            this.status = status;
        }
        public HttpRes(int status, string msg)
        {
            this.status = status;
            this.msg = msg;
        }

        public HttpRes(int status, dynamic obj)
        {
            this.status = status;
            this.obj = obj;
        }


        public HttpRes(int status, string msg, dynamic obj)
        {
            this.obj = obj;
            this.status = status;
            this.msg = msg;
        }

        public IActionResult HttpResponse()
        {

            return this.status switch
            {
                200 => Ok(this.obj),
                201 => new ObjectResult(this.obj),
                202 => Accepted(this.obj),
                204 => NoContent(),
                400 => BadRequest(this.msg),
                401 => Unauthorized(this.msg),
                404 => NotFound(this.msg),
                _ => BadRequest("Resposta não identificada!"),

            };
        }
    }
}
