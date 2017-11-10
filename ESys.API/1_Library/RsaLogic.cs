
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ESys.DB;
using System.Security.Cryptography;

namespace ESys.Library
{
    
    public class RsaLogic
    {
        static ESys_DBContext _db = new ESys_DBContext();
        public static string EMailEncryLogic(string EncryptString)
        {
            RSACryptoServiceProvider _RSA = new RSACryptoServiceProvider();
            string EncryptBase64 = string.Empty;
            var query = _db.RSA_Key.Where(o => o.RSA_Type == "EMail").Select(o => o.PublicKey).FirstOrDefault();
            if (query.Any())
            {
                _RSA.FromXmlString(query);
                var Encrypt = Convert.ToBase64String(_RSA.Encrypt(Encoding.UTF8.GetBytes(EncryptString), false));
                byte[] bytes = Encoding.UTF8.GetBytes(Encrypt);
                EncryptBase64 = Convert.ToBase64String(bytes);
            }
            return EncryptBase64;
        }
        public static string EMailDecryLogic(string DecryptString)
        {
            RSACryptoServiceProvider _RSA = new RSACryptoServiceProvider();
            string DecryptBase64 = string.Empty;
            var query = _db.RSA_Key.Where(o => o.RSA_Type == "EMail").Select(o => o.PrivateKey).FirstOrDefault();
            if (query.Any())
            {
                _RSA.FromXmlString(query);
                byte[] bytes = Convert.FromBase64String(DecryptString);
                DecryptString = Encoding.UTF8.GetString(bytes);
                DecryptBase64 = Encoding.UTF8.GetString(_RSA.Decrypt(Convert.FromBase64String(DecryptString), false));
            }
            return DecryptBase64;
        }
    }
}