using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetWellWebApplication.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error()
        {
            var qs = HttpUtility.ParseQueryString(Request.Url.Query);
            var errorPath = qs["aspxerrorpath"];

            return View(model: errorPath);
        }

        public ActionResult PageFor404()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PageFor404Post()
        {
            return RedirectToAction("Accueil", "Home");
        }
        public ActionResult PageFor500()
        {
            return View();
        }
    }
}