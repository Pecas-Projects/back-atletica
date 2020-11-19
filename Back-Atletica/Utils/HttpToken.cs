using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Back_Atletica.Utils
{
    public class HttpToken
    {

        public static long GetUserId(HttpContext context)
        {
            var identity = context.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();

            var id = claim[0].Value;

            return Convert.ToInt32(id);
        }

        public static string GetUserType(HttpContext context)
        {
            var identity = context.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();

            var tipo = claim[3].Value;

            return tipo;
        }

        public static string GetTokenType(HttpContext context)
        {
            var identity = context.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();

            string type = claim[2].Value;

            return type;
        }
    }
}
