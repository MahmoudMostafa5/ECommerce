using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.Helper
{
    public static class mailSender
    {
        public static string sendMail(string Title, string Message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add("moodymostafa224@gmail.com");
                mail.From = new MailAddress("ma7moudmostafa224@gmail.com");
                mail.Subject = Title;
                mail.Body = Message;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("ma7moudmostafa224@gmail.com", "01550331928");
                smtp.Send(mail);

                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com";
                //smtp.Port = 587;
                //smtp.UseDefaultCredentials = false;
                //smtp.EnableSsl = true;

                //smtp.Credentials= new NetworkCredential("as8338873@gmail.com", "A@123321A@");
                //smtp.Send("as8338873@gmail.com", "amltest81@gmail.com","test","test");

                return "Mail Sent Successfully";


            }
            catch (Exception ex)
            {
                return "Mail Faild";
            }
        }
    }
}
