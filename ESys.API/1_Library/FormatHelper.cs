using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ESys.Library
{
    public class FormatLibrary
    {
        /// <summary>
        /// 將 Dictionary 轉換為Json String
        /// </summary>
        /// <param name="_Dictionary"></param>
        /// <returns></returns>
        public static string DictionaryToJson(Dictionary<string,string> _Dictionary)
        {
            List<Dictionary<string, string>> _JsonFormat = new List<Dictionary<string, string>>();
            _JsonFormat.Add(_Dictionary);
            return JsonConvert.SerializeObject(_JsonFormat);
        }
    }
}