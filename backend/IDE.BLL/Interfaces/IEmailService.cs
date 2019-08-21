using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailVerificationMail(string receiverEmail, string confirmationToken);
    }
}
