using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.SessionState;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Onyx.Core;
using Onyx.Data;
using Onyx.Service;
using Onyx.Models;
using Onyx.Web.Framework;

namespace Onyx.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Detail(int id)
        {
            var traer = new CustomerService();
            var res = traer.GetCustomerSettingByID(id);
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
        [HttpGet]
        public ActionResult DetailSettings(CustomerSetting model,int? page)
        {
            var user = new CustomerService();
            if (true)//AdminLogueado()==1)
            {
                var lista = new CustomerService();
                var listaCompleta = lista.GetCustomerSettings(model.KeyID);
                var paginador=new Paginador(listaCompleta.Count(),5);
                var viewModel = new PaginadorViewModel
                {
                    Items = listaCompleta.Skip((paginador.CurrentPage - 1) * paginador.PageSize).Take(paginador.PageSize),
                    Paginador = paginador
                };
                return View(viewModel);
            }
            else
            {
                //return View("NAAAAAAAAAAAA");
            }

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
            return RedirectToAction("DetailSetting");//RedirectToAction("Detail", new { id = e.CustomerSettingID }); 
            
        }
        public ActionResult Edit(int id)
        {
            var UserValidated = new ValidateUser();
                UserValidated = (ValidateUser)Session["Account"];
            
            if ((int)UserValidated.Rol == (int)EnumRol.Admin)
            {
                var conf = new CustomerService();
                var e = conf.GetCustomerSettingToEdit(id);
                var elem = new CustomerSettingModels();
                elem.CustomerSettingID = e.CustomerSettingID;
                elem.KeyID = e.KeyID;
                elem.Name = e.Name;
                elem.Value = e.Value;
                return View(elem);
            }else
            {
                return RedirectToAction("Index","Home");
            }
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