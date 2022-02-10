using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace YogaMockUp.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using(MailMessage mailMessage = new MailMessage())
            {

                mailMessage.From = new MailAddress("jerome.marvin5@ethereal.email");
                mailMessage.Subject = subject;
                mailMessage.Body = email + htmlMessage;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress("@gmail.com"));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.ethereal.email";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential();
                networkCredential.UserName = "Jerome Marvin";
                networkCredential.Password = "U4MekyUV9Zdt7GYeJj";
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = networkCredential;
                smtp.Port = 587;
                await smtp.SendMailAsync(mailMessage);

            }
        }
    }
}
