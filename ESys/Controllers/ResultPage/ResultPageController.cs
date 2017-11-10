using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ESys.Controllers.ResultPage
{
    public class ResultPageController : Controller
    {
        // GET: ResultPage
        [AllowAnonymous]
        public ActionResult FinishRegistered()
        {
            ViewBag.Body = "恭喜註冊完成！請記得去申請信箱開通才可以登入哦！";
            return View();
        }
    }
}