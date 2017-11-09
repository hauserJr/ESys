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
        [Authorize(Roles = "Member")]
        public ActionResult Member()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View();
        }
    }
}