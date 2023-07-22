﻿using IsSistemVakaTask.Models.Dtos;
using IsSistemVakaTask.Services.Interfaces;
using System.Net.Mail;
using System.Net;

namespace IsSistemVakaTask.Services
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(EmailModel email)
        {
            try
            {
                var modelEmail = Extension.EmailInformation.GetEmailInformation();
                var senderEmail = modelEmail.Item1;
                var senderPassword = modelEmail.Item2;
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
