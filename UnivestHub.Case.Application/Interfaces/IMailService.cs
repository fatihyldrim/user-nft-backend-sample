using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivestHub.Case.Application.Interfaces
{
    public interface IMailService
    {
        Task SendMail(string emailAddress, string smtpAddress, string senderMail, string senderPassword, string code);
    }
}
