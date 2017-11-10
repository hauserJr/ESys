using ESys.DB;
using ESys.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ESys.Controllers.Verity
{
    public class VerifyController : Controller
    {
        private ESys_DBContext _db = new ESys_DBContext();

        [AllowAnonymous]
        // GET: Verify
        public ActionResult VerifyAccount(string CodeStr)
        {
            string Meg = "驗證失敗，請重新註冊！";
            string VerifyResult = RsaLogic.EMailDecryLogic(CodeStr);
            if (!string.IsNullOrEmpty(VerifyResult))
            {
                Guid Account_Guid = Guid.Parse(VerifyResult);
                string Message = string.Empty;
                var query = _db.Local_Account.Where(o => o.Account_Guid == Account_Guid && o.EmailCheck == false);
                if (query.Any())
                {
                    try
                    {
                        query.FirstOrDefault().EmailCheck = true;
                        _db.SaveChanges();
                        Meg = "驗證成功，請進行登入！";
                    }
                    catch
                    {

                    }                   
                }            
            }
            ViewBag.Meg = Meg;
            _db.SaveChanges();
            return View();
        }
    }
}