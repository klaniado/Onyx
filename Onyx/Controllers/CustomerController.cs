using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Onyx.Core;
using Onyx.Data;
using Onyx.Service;
using Onyx.Models;

namespace Onyx.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Detail(int id)
        {
            var traer = new CustomerService();
            var res = traer.GetCustomerSetting(id);
            var model = new CustomerSettingModels();
            model.CustomerSettingID = res.CustomerSettingID;
            model.KeyID = res.KeyID;
            model.Name = res.Name;
            model.Value = res.Value;

            return View(model);
        }
        public ActionResult DetailSetting()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DetailSettings(CustomerSettings model)
        {
            var lista = new CustomerService();
            var a = lista.GetCustomerSettings(model.KeyID);
            List<CustomerSettingModels> viewmodel = new List<CustomerSettingModels>();
            foreach (var e in a)
            {
                var elem = new CustomerSettingModels();
                elem.CustomerSettingID = e.CustomerSettingID;
                elem.KeyID = e.KeyID;
                elem.Name = e.Name;
                elem.Value = e.Value;


                viewmodel.Add(elem);
            }
            return View(viewmodel);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CustomerSettingModels e)
        {
            var conf = new CustomerService();
            var elem = new CustomerSetting();
            elem.KeyID = e.KeyID;
            elem.Name = e.Name;
            elem.Value = e.Value;
            conf.SaveCreate(elem);
            return RedirectToAction("Detail", new { id = e.CustomerSettingID }); 
            
        }
        public ActionResult Edit(int id)
        {
            var conf = new CustomerService();
            var e = conf.GetCustomerSettingToEdit(id);
            var elem = new CustomerSettingModels();
            elem.CustomerSettingID = e.CustomerSettingID;
            elem.KeyID = e.KeyID;
            elem.Name = e.Name;
            elem.Value = e.Value;
            return View(elem);
        }
        [HttpPost]
        public ActionResult Edit(CustomerSettingModels e)
        {
            var conf = new CustomerService();
            var elem = new CustomerSetting();
            elem.CustomerSettingID = e.CustomerSettingID;
            elem.KeyID = e.KeyID;
            elem.Name = e.Name;
            elem.Value = e.Value;
            conf.SaveEdit(elem);
            return RedirectToAction("Detail", new { id = e.CustomerSettingID }); ;
        }

    }
}