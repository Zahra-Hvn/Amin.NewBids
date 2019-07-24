using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewBid_Admin.Controllers
{
    public class ErrorHandlerController : Controller
    {
        // GET: ErrorHandler
        public ActionResult Index(string aspxerrorpath)
        {
            ViewBag.path = aspxerrorpath;

            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = 404;


            return View();
        }
    }
}