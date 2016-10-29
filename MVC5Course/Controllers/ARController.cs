using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
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
    }
}