using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Web;

namespace ESys.Library
{
    public class DataCheckLibrary
    {
        /// <summary>
        /// 確認信箱格式是否正常
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public static Dictionary<bool, string> IsValidEMailAddress(string Email)
        {
            string RegexStr = string.Format(@"^([\w-]+\.)*?[\w-]+@[\w-]+\.([\w-]+\.)*?[\w]+$");
            Dictionary<bool, string> _Dictionary = new Dictionary<bool, string>();
            if (!Regex.IsMatch(string.IsNullOrEmpty(Email) ? "" : Email, RegexStr))
            {
                _Dictionary.Add(false,"Email格式錯誤。");
            }
            else
            {
                _Dictionary.Add(true, "");
            }
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
            Dictionary<bool, string> _Dictionary = new Dictionary<bool, string>();
            List<string> ErrorMeg = new List<string>();
            
            //判斷密碼是否為空值,密碼長度是否正常,前後是否一致
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
            
            if (ErrorMeg.Count > 0)
            {
                _Dictionary.Add(false, string.Join("\n", ErrorMeg));
            }
            else
            {
                _Dictionary.Add(true,"");
            }
            return _Dictionary;
        }
    }
}