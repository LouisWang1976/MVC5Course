using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FileImg()
        {
            var filePath = Server.MapPath("~/Content/img/0809-003.jpg");
            return File(filePath, "image/jpeg");
        }
        public ActionResult FileImgDownload()
        {
            var filePath = Server.MapPath("~/Content/img/0809-003.jpg");
            return File(filePath, "image/jpeg","idf.jpg");
        }
        public ActionResult JsonReturn()
        {
            db.Configuration.LazyLoadingEnabled = false;
            var data = db.Product.OrderBy(p => p.ProductId).Take(10);
            return Json(data.ToList(),JsonRequestBehavior.AllowGet);
        }
    }
}