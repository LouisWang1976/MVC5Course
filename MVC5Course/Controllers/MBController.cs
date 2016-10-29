using MVC5Course.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : Controller
    {
        // GET: MB
        public ActionResult Index()
        {
            ViewData["Temp1"] = "暫存1";
            var B = new ClientLoginViewModel() {
                FirstName = "Wang",
                LastName="Louis"

            };
            ViewData["Temp2"] = B;
            ViewBag.Temp3 = B;
            return View();
        }
        public ActionResult MyForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MyForm(ClientLoginViewModel c)
        {
            if (ModelState.IsValid == true)
            {
                TempData["MyFormData"] = c;
                return RedirectToAction("MyFormResult");
            }
            return View();
        }
        public ActionResult MyFormResult(ClientLoginViewModel c)
        {
            return View();
        }
    }
}