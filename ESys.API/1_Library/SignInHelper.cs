using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace ESys.Library
{
    public class SignInLibrary
    {
        /// <summary>
        /// Login時存入Cookie的值
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Sid"></param>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        public static ClaimsIdentity UpdateIdentity(string Name, string Sid, string RoleName)
        {
            var Identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, Name),
                    new Claim(ClaimTypes.Sid, Sid),
                    new Claim(ClaimTypes.Role, RoleName)
                }, "UserCookie");
            return Identity;
        }
    }
}