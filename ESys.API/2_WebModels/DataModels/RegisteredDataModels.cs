using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ESys.DataModels
{
    public class RegisteredDataModels
    {
        public Guid Account_Guid {
            get { return Guid.NewGuid(); }
            set { Account_Guid = value; }
        }

        public string UserAccount { get; set; }

        public string NickName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}