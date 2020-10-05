using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using f12020.Models;

namespace f12020.Controllers
{
    public class AuthenticatorController : ApiController
    {
        private Database1Entities db = new Database1Entities();
        [Route("api")]
        public Boolean AutenticaToken(int idusuario, String token)
        {

            return true;

           // bool auth = Role.GetRolesForUser;


        }
    }
}
