using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CacheManager.Core;
using Onyx.Data;
using Onyx.Core;
namespace Onyx.Service
{
    public partial class CustomerService
    {
        public List <CustomerSetting> GetCustomerSettings(int id)
        {
            var objectContext = new ObjectOnyxContext();
            var list = objectContext.CustomerSettings.Where(x => x.KeyID == id).Select(x => x).ToList();
            var settings = new List<CustomerSetting>();
            if (list != null)
            {
                foreach(var e in list)
                {
                    var elem = new CustomerSetting();
                    elem.Name = e.Name;
                    elem.KeyID = e.KeyID;
                    elem.CustomerSettingID = e.CustomerSettingID;
                    elem.Value = e.Value;
                    settings.Add(elem);
                }
                var a = new List<CustomerSetting>();

                return settings;
            }
            else
            {
                var a = new List<CustomerSetting>();
                return a;
            }
        }
        public CustomerSetting GetCustomerSettingToEdit(int id)
        {
            var objectContext = new ObjectOnyxContext();
            var e = objectContext.CustomerSettings.Where(x => x.CustomerSettingID == id).Select(x => x).SingleOrDefault();
            var elem = new CustomerSetting();
            elem.Name = e.Name;
            elem.KeyID = e.KeyID;
            elem.CustomerSettingID = e.CustomerSettingID;
            elem.Value = e.Value;
            return elem;
        }
        public CustomerSetting GetCustomerSettingByID(int id)
        {
            var objectContext = new ObjectOnyxContext();
            var model = new CustomerSetting();
            var buscar = objectContext.CustomerSettings.Find(id);
                model.CustomerSettingID = buscar.CustomerSettingID;
                model.KeyID = buscar.KeyID;
                model.Name= buscar.Name;
                model.Value = buscar.Value;

            return model;
        }
        public void SaveCreate(CustomerSetting model)
        {
            var objectContext = new ObjectOnyxContext();
            objectContext.CustomerSettings.Add(model);
            objectContext.SaveChanges();
        }
        public void SaveEdit(CustomerSetting model)
        {
            var objectContext = new ObjectOnyxContext();
            var conv = objectContext.CustomerSettings.Find(model.CustomerSettingID);
            conv.CustomerSettingID = model.CustomerSettingID;
            conv.KeyID = model.KeyID;
            conv.Name = model.Name;
            conv.Value = model.Value;
            objectContext.SaveChanges();
        }

      /*  public int AdminLogueado()
        {
            var user = new Usuario();
            var cache = CacheManager.SystemRuntimeCaching.MemoryCacheHandle;
            var rol = cache.Get("Rol");
            var existe = cache.Exists("Rol");
            if (existe==true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
            
        }*/

    }
}
