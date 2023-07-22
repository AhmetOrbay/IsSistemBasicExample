using IsSistemVakaTask.Services.Interfaces;
using System.Net.Mail;
using System.Net;
using IsSistemVakaTask.Models.ExtensionModels;

namespace IsSistemVakaTask.Services
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(EmailModel email)
        {
            try
            {
                var modelEmail = Extension.EmailInformation.GetEmailInformation();
                var senderEmail = modelEmail.EmailAddress;
                var senderPassword = modelEmail.Password;
                string senderHost = "smtp.gmail.com";
                int senderPort = 587;
                bool enableSsl = true;

                SmtpClient smtpClient = new SmtpClient(senderHost, senderPort)
                {
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = enableSsl
                };

                MailMessage mail = new MailMessage(senderEmail, email.Recipient)
                {
                    Subject = email.Subject,
                    Body = email.Message
                };

                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception($"Email Send Error : {ex.Message}");
            }
            return true;
        }
    }
}
