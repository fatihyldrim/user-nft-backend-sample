using UnivestHub.Case.Application.Interfaces;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Infrastructure
{
    public class MailService : IMailService
    {
        public async Task SendMail(string emailAddress, string smtpAddress, string senderMail, string senderPassword, string code)
        {
            try
            {
                var email = new MimeMessage();

                email.From.Add(new MailboxAddress("UnivestHub Case", senderMail));
                email.To.Add(new MailboxAddress("Receiver Name", emailAddress));

                email.Subject = "UnivestHub Case Login Code";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = $"<p> Your code is <b>{code}</b> <p>"
                };

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587, false);

                    smtp.Authenticate(senderMail, senderPassword);

                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
