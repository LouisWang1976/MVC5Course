using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();
        // GET: EF
        public ActionResult Index()
        {
            
            var data = db.Product.Where(p => p.ProductName.Contains("White"));
            return View(data);
        }
        public ActionResult Create()
        {
            var l_product = new Product()
            {
                ProductName = "WhiteTest1",
                Stock = 5,
                Active = true,
                Price=10
                
            };
            db.Product.Add(l_product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Details(Int32 id )
        {
            var l_product = db.Product.Find(id);
            return View(l_product);
        }
        public ActionResult Delete(Int32 id)
        {
            var l_product = db.Product.Find(id);
            var orderline = l_product.OrderLine;
            db.OrderLine.RemoveRange(orderline);
            db.Product.Remove(l_product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var product = db.Product.Find(id);
            product.ProductName = product.ProductName + "!";
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                if(ex.GetType().ToString()== "System.Data.Entity.Validation.DbEntityValidationException")
                {
                    DbEntityValidationException vex = (DbEntityValidationException)ex;
                    foreach (var eValidation in vex.EntityValidationErrors)
                    {
                        foreach (var vErro in eValidation.ValidationErrors)
                        {
                            throw new Exception("驗證失敗:" + vErro.ErrorMessage);
                        }
                    }
                }
                


                throw;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Add5Percernt()
        {
            var data = db.Product.Where(p => p.ProductName.Contains("White"));
            foreach(var temp in data)
            {
                if(temp.Price.HasValue)
                {
                    temp.Price = temp.Price * 1.05m;
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}