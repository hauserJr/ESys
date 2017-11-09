using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(ESys.App_Start.Startup))]

namespace ESys.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 如需如何設定應用程式的詳細資訊，請參閱  http://go.microsoft.com/fwlink/?LinkID=316888'
            
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                //作為辨識的的Cookie屬性
                AuthenticationType = "UserCookie",
                //如果無權限存取401 最後導頁的位置
                LoginPath = new PathString("/Home/index")
            });
            ConfigureAuth(app);
        }
    }
}