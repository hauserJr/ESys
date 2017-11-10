using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESys.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Admin()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult About()
        {
            return View();
        }
    }
}