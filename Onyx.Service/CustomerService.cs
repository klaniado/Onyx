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
    public partial class CustomerService
    {
        public List <CustomerSetting> GetCustomerSettings(int id)
        {
            var objectContext = new OnyxEntities1();
            var list = objectContext.CustomerSetting.Where(x => x.KeyID == id).Select(x => x).ToList();
            if (list != null)
            {
                return list;
            }
            else
            {
                return null;
            }
        }
    }
}
