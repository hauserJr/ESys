using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Web;
using ESys.DB;
namespace ESys.Library
{
    public class DataCheckLibrary
    {
        
       
        private static ESys_DBContext _db = new ESys_DBContext();

        /// <summary>
        /// 確認信箱格式是否正常及是否存在
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public static Dictionary<bool, string> IsValidEMailAddress(string Email)
        {
            List<string> ErrorMeg = new List<string>();
            Dictionary<bool, string> _Dictionary = new Dictionary<bool, string>();

            #region 驗證Email格式及是否存在
            string RegexStr = string.Format(@"^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$");
            var query = _db.Local_Account.Where(o => o.UserAccount == Email).Any();
            if (!query)
            {
                if (!Regex.IsMatch(string.IsNullOrEmpty(Email) ? "" : Email, RegexStr))
                {
                    ErrorMeg.Add("Email格式錯誤。");
                }
            }
            else
            {
                ErrorMeg.Add("Email已存在。");
            }
            #endregion
            _Dictionary.Add(ErrorMeg.Any(), string.Join(",", ErrorMeg));
            return _Dictionary;

        }

        /// <summary>
        /// 判斷密碼是否為空值,密碼長度是否正常,前後是否一致
        /// </summary>
        /// <param name="Password"></param>
        /// <param name="ConfirmPassword"></param>
        /// <param name="PasswordLeng"></param>
        /// <returns></returns>
        public static Dictionary<bool, string> RecheckPassword(string Password,string ConfirmPassword,int PasswordLeng)
        {
            List<string> ErrorMeg = new List<string>();
            Dictionary<bool, string> _Dictionary = new Dictionary<bool, string>();

            #region 判斷密碼是否為空值,密碼長度是否正常,前後是否一致
            if (!string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfirmPassword))
            {
                if (Password.Length < PasswordLeng || ConfirmPassword.Length < PasswordLeng)
                {
                    ErrorMeg.Add("密碼長度需大於"+ PasswordLeng + "個字。");
                   
                }
                else
                {
                    if (!Password.Equals(ConfirmPassword))
                    {
                        ErrorMeg.Add("密碼前後輸入不一致。");
                    }
                }                
           }
           else
           {
                ErrorMeg.Add("密碼不可為空值。");
           }
            #endregion

            _Dictionary.Add(ErrorMeg.Any(), string.Join(",", ErrorMeg));
            return _Dictionary;
        }
    }
}