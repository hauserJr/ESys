﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ESys.DB;
using ESys.DataModels;
using ESys.Library;
using System.IO;
using ESys.DataModels.DataModels;

namespace ESys.Controllers
{
    public class AccountController : Controller
    {
        #region Db宣告區
        private ESys_DBContext _db = new ESys_DBContext();
        #endregion

        #region IAuthenticationManager
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        #endregion

        private string JsonContentType = string.Format("application/json");
        /**************************************************************************************************/
        /*******************************************Action Start*******************************************/
        /**************************************************************************************************/
        // GET: /Account/Login
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Local_AccountDataModels _Local_AccountDataModels)
        {
            var query = _db.Local_Account
                .Where(o => o.UserAccount == _Local_AccountDataModels.UserAccount
                 && o.Password == _Local_AccountDataModels.Password).FirstOrDefault();
            if (query != null)
            {
                string Tip = query.EmailCheck ? "已開通" : "未開通";
                var AuthManager = Request.GetOwinContext().Authentication;
                AuthManager.SignIn(SignInLibrary.UpdateIdentity(query.UserAccount + Tip, query.Account_Guid.ToString(), "Member"));
                return Content("true");
            }
            return Content("false") ;
        }

        // POST: /Account/Registered
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Registered(RegisteredDataModels _RegisteredDM)
        {
            //return 
            Dictionary<string, string> _JsonDictionary = new Dictionary<string, string>();

            var ValidEMail = DataCheckLibrary.IsValidEMailAddress(_RegisteredDM.UserAccount);
            var RecheckPwd = DataCheckLibrary.RecheckPassword(_RegisteredDM.Password, _RegisteredDM.ConfirmPassword,8);
            if (ValidEMail.ContainsKey(true))
            {
                _JsonDictionary.Add("Mail", ValidEMail[true]);
            }
            if (RecheckPwd.ContainsKey(true))
            {
                _JsonDictionary.Add("Pwd", RecheckPwd[true]);
            }

            #region 判斷是否有錯誤訊息
            if (_JsonDictionary.Count > 0)
            {
                var FormatJson = FormatLibrary.DictionaryToJson(_JsonDictionary);
                return Content(FormatJson, JsonContentType);
            }
            else
            {
                _RegisteredDM.Account_Guid = Guid.NewGuid();
                _db.Local_Account.Add(new Local_Account
                {
                    Account_Guid = _RegisteredDM.Account_Guid,
                    UserAccount = _RegisteredDM.UserAccount,
                    Password = _RegisteredDM.Password,
                    EmailCheck = false,
                    CreateDateTime = System.DateTime.Now
                });
                _db.SaveChanges();
                string HtmlTemp = string.Empty;
                try
                {
                    using (StreamReader _StreamReader = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + "/Temp/mail_temp.html"))
                    {
                        HtmlTemp = _StreamReader.ReadToEnd();
                        HtmlTemp = HtmlTemp.Replace("【CodeReplace】", RsaLogic.EMailEncryLogic(_RegisteredDM.Account_Guid.ToString()));
                        SendMailLibrary.RealTimeSendMail(HtmlTemp,"歡迎註冊", _RegisteredDM.UserAccount);
                    }
                }
                catch (Exception ex)
                {
                    //
                }
            }
            #endregion
            _JsonDictionary.Add("Reg","註冊成功，請至信箱開通。");
            var Reg_FormatJson = FormatLibrary.DictionaryToJson(_JsonDictionary);
            return Content(Reg_FormatJson, JsonContentType);
        }

        #region 登出
        // POST: /Account/LogOff
        [HttpPost]
        public ActionResult LogOff()
        {
            try
            {
                AuthenticationManager.SignOut("UserCookie");
                return Content("成功登出");
            }
            catch (Exception ex)
            {
                return Content("");
            }
        }
        #endregion

        #region 原生MVC外部登入Action含Helper
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // 要求重新導向至外部登入提供者
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var FB_Info = await AuthenticationManager.GetExternalLoginInfoAsync();
            var AccountCheck = _db.FB_Account.Where(o => o.ProviderKey == FB_Info.Login.ProviderKey).Any();

            //檢查資料庫是否有資料
            if (!AccountCheck)
            {
                //將資料註冊入Table
                _db.FB_Account.Add(new FB_Account
                {
                    FBAccount_Guid = Guid.NewGuid(),
                    Email = FB_Info.Email,
                    ProviderKey = FB_Info.Login.ProviderKey

                });
                _db.SaveChanges();
            }

            var query = _db.FB_Account.Where(o => o.ProviderKey == FB_Info.Login.ProviderKey).FirstOrDefault();
            var AuthManager = Request.GetOwinContext().Authentication;
            AuthManager.SignIn(SignInLibrary.UpdateIdentity(query.Email, query.FBAccount_Guid.ToString(), "Member"));

            return RedirectToAction("Index","Home");
        }

        #region 外部登入Helper(原MVC Temp寫法)
        // 新增外部登入時用來當做 XSRF 保護
        private const string XsrfKey = "XsrfId";


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion

        #endregion
    }
}