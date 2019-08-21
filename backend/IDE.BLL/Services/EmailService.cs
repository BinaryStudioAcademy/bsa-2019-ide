using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IDE.BLL.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace IDE.BLL.Services
{
    public class EmailService : IEmailService
    {
        const string currentAddress = "https://bsa-ide.azurewebsites.net"; //How to set it

        private readonly SendGridClient client;

        public EmailService(string apiKey)
        {
            client = new SendGridClient(apiKey);
        }

        public async Task SendEmailVerificationMail(string receiverEmail, string verificationToken)
        {            
            var from = new EmailAddress("support@onlineIde.com", "Online IDE");
            var to = new EmailAddress("anatolii.0700@gmail.com", "EmailConfirm");

            var subject = "Please, confirm your mail";

            var plainTextContent = "Confirm your email";
            var htmlContent = string.Format("<div style=\"width: 60%!important; padding: 20px; border: 1px solid #f0f0f0; margin: 30px auto!important; display: block!important\">" + 
                                                "<h3 style=\"font-size: 24px; color: #294661; font-weight: 300; margin-bottom: 10px\">You're on your way!</h3>" +
                                                "<h3 style=\"font-size: 24px; color: #294661; font-weight: 300; margin-bottom: 50px; margin-top: 0\"> Let's confirm your email address.</h3>" +
                                                "<p style=\"color: #294661;\">By clicking on the following link, you are confirming your email address.</p>" +
                                                "<a href=\"{0}/vf?vcd={1}\" style=\"text-decoration: none\">" +
                                                "   <button style=\"width: 200px; padding: 20px; color: #f0f0f0; border: none; background: #5db4e9; font-size: 14px; margin: 20px auto; display: block; cursor: pointer!important;\">Confirm Email Address</button></a>" +
                      "</div>", currentAddress, verificationToken);

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
