using ESys.DB;
using System.Collections.Generic;
using System.Net.Mail;

namespace ESys.Library
{
    public class SendMailLibrary
    {
        private static ESys_DBContext _db = new ESys_DBContext();
        public static void RealTimeSendMail(string HtmlTemp,string HtmlTitle,string MailTo)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(string.Join(",", MailTo));
            msg.From = new MailAddress("free576002@gmail.com", "測試郵件", System.Text.Encoding.UTF8);
            //郵件標題 
            msg.Subject = HtmlTitle;
            //郵件標題編碼  
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            //郵件內容
            msg.Body = HtmlTemp;
            msg.IsBodyHtml = true;
            msg.BodyEncoding = System.Text.Encoding.UTF8;//郵件內容編碼 
            msg.Priority = MailPriority.Normal;
            SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);
            //設定你的帳號密碼
            MySmtp.Credentials = new System.Net.NetworkCredential("free576002@gmail.com", "tvom_1218");
            //Gmial 的 smtp 使用 SSL
            MySmtp.EnableSsl = true;
            MySmtp.Send(msg);
        }
    }
}