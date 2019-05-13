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
    }
}
