using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Onyx.Data;

namespace Onyx.Service
{
    public partial class CustomerService
    {
        public List <CustomerSetting> GetCustomerSettings(int id)
        {
            var objectContext = new OnyxEntities2();
            var list = objectContext.CustomerSetting.Where(x => x.KeyID == id).Select(x => x).ToList();
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
            var objectContext = new OnyxEntities2();
            var e = objectContext.CustomerSetting.Where(x => x.CustomerSettingID == id).Select(x => x).SingleOrDefault();
            var elem = new CustomerSetting();
            elem.Name = e.Name;
            elem.KeyID = e.KeyID;
            elem.CustomerSettingID = e.CustomerSettingID;
            elem.Value = e.Value;
            return elem;
        }
        public CustomerSetting GetCustomerSetting(int id)
        {
            var objectContext = new OnyxEntities2();
            var model = new CustomerSetting();
            var buscar = objectContext.CustomerSetting.Find(id);
                model.CustomerSettingID = buscar.CustomerSettingID;
                model.KeyID = buscar.KeyID;
                model.Name= buscar.Name;
                model.Value = buscar.Value;

            return model;
        }
        public void SaveCreate(CustomerSetting model)
        {
            var objectContext = new OnyxEntities2();
            objectContext.CustomerSetting.Add(model);
            objectContext.SaveChanges();
        }
        public void SaveEdit(CustomerSetting model)
        {
            var objectContext = new OnyxEntities2();
            var conv = objectContext.CustomerSetting.Find(model.CustomerSettingID);
            conv.CustomerSettingID = model.CustomerSettingID;
            conv.KeyID = model.KeyID;
            conv.Name = model.Name;
            conv.Value = model.Value;
            objectContext.SaveChanges();
        }



    }
}
