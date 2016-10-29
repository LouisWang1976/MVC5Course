using System;
using System.Web.Mvc;
namespace MVC5Course.Controllers
{
    public class ShareTempDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewData["Temp1"] = "暫存1";
        }
    }
}