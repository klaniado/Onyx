using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onyx.Core;
using Onyx.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CacheManager.Core;

namespace Onyx.Service
{
    public partial class AccountService
    {
        public void SaveUser(Usuario usuario)
        {
            var objectContext = new ObjectOnyxContext();
            objectContext.Usuarios.Add(usuario);
            objectContext.SaveChanges();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public ValidateUser ValidateUser(Usuario usuario)
        {
            var objectContext = new ObjectOnyxContext();
            //     var list=objectContext.Usuarios.Select(x => x).ToList();
            var user = objectContext.Usuarios.Where(x => x.Usuario1 == usuario.Usuario1).Select(x => x).SingleOrDefault();
            var objeto = new ValidateUser();
            if (user == null || user.Pasword != usuario.Pasword )
            {
                objeto.IsValidated = false;
                objeto.ErrorMessage = "Usuario o Contraseña incorrectos";
                objeto.Status = 1;
                return objeto;
            }
            else
            {
                objeto.IsValidated = true;
                objeto.Rol = (EnumRol)user.RolID;
                return objeto;
            }
        }
    }
}
