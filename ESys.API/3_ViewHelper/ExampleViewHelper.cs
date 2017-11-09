using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace ESys.ViewHelper
{
    public static class ExampleViewHelper
    {
        /// <summary>
        /// View Helper Test Example
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static MvcHtmlString ExampleShowText(this HtmlHelper helper, string text)
        {
            
            return MvcHtmlString.Create("<font color='red'>Test View Helper</font>");
        }
    }
}
