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
            Guid Account_Guid = Guid.Parse(RsaLogic.EMailDecryLogic(CodeStr));
            var query = _db.Local_Account.Where(o => o.Account_Guid == Account_Guid);
            if (query.Any())
            {
                query.FirstOrDefault().EmailCheck = true;
            }

            _db.SaveChanges();
            return View();
        }
    }
}