
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ESys.DataModels.DataModels
{
    public class Local_AccountDataModels
    {
        public Guid Account_Guid { get; set; }

        public string UserAccount { get; set; }

        public string Password { get; set; }

        public bool EmailCheck { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}