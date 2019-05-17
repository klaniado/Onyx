using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Onyx.Models;

namespace Onyx.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult DetailSetting(int id)
        {
            var model = new Customer();
            return View(model);
        }
    }
}