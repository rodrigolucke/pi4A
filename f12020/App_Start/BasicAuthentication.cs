using f12020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Security.Principal;
using System.Threading;


namespace f12020
{
    public class BasicAuthentication : AuthorizationFilterAttribute
    {

        private f1apiEntities db = new f1apiEntities();
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string token = actionContext.Request.RequestUri.Segments[3].Split('/')[0];
            string userid = actionContext.Request.RequestUri.Segments[2].Split('/')[0];
            /*código abaixo cria uma session para armazenar o nome do usuário*/
           
            int id = Convert.ToInt32(userid);
            usuario_token ut = db.usuario_token.Where(
             p => p.usuario_id_usuario.Equals(id))
                .Where(x => x.token.Equals(token)).FirstOrDefault();
            if (ut == null)
            {
               
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {              
                if(ut != null)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userid), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }
            }
        }

       
    }
}