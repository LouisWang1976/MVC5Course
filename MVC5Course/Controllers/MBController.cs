using MVC5Course.Models;
using MVC5Course.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : BaseController
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
        public ActionResult ProductList()
        {
            var data = db.Product.OrderByDescending(p => p.ProductId).Take(10);
            return View(data);
        }
        public ActionResult BatchUpdate(ProductBatchViewModel[] items)
        {
            if(ModelState.IsValid)
            {
                foreach (ProductBatchViewModel item in items)
                {

                    Product l_Product = db.Product.Find(item.ProductId);
                    l_Product.ProductName = item.ProductName;
                    l_Product.Price = item.Price;
                    l_Product.Active = item.Active;
                    l_Product.Stock = item.Stock;

                }
                db.SaveChanges();
                return RedirectToAction("ProductList");
            }
            
             
            return View();
        }
    }
}