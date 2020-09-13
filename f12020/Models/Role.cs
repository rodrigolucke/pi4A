using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using f12020.Models;
using System.Web.Security;

namespace f12020.Models
{
    public class Role : RoleProvider
    {
       
        private f1apiEntities db = new f1apiEntities();
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public BasicAuthentication HttpContext { get; private set; }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {


            List<string> list = new List<string>();
            usuario p1 = db.usuario.Where(
                  p => p.login_usuario.Equals(username)).FirstOrDefault();

            String[] retorno;
            if (p1 != null)
            {
                list.Add("ok");
            }
            else
            {
                list.Add("no");
            }
            /* foreach (usuario_grupo ug in usuarioGrupo)
             {

                 list.Add(ug.grupo.nome_grupo);

             }*/

            list.Add("ok");
            retorno = list.ToArray();


                return retorno;
            throw new Exception("Sem Acesso");

        }

        public int userId(string username)
        {
            usuario p1 = db.usuario.Where(
                 p => p.login_usuario.Equals(username)).FirstOrDefault();
            return p1.id_usuario;
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }

}

