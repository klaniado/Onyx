using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onyx.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace Onyx.Service
{
    public partial class AccountService
    {
        public void SaveUser(Usuario usuario)
        {
            var objectContext = new OnyxEntities();
            objectContext.Usuarios.Add(usuario);
            objectContext.SaveChanges();
        }
        public int LoginUser(Usuario usuario)
        {
            var objectContext = new OnyxEntities();
       //     var list=objectContext.Usuarios.Select(x => x).ToList();
            var user = objectContext.Usuarios.Where(x => x.Usuario1 == usuario.Usuario1).Select(x=>x).SingleOrDefault();
            if (user==null)
            {
                return 0;
            }
            else
            {
                if (user.Pasword == usuario.Pasword)
                {
                    return 1;
                }else
                {
                    return 2;
                }
            }
            
        }
    }
}
