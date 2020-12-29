using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Email_Html_POC.Utilities.Common;
using System.IO;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Email_Html_POC.Services
{
    public class EmailNotificationService : IEmailNotificationService
    {
        private readonly IConfiguration _configuration;
        private readonly ICommonHelperService _commonHelperService;
        public EmailNotificationService(IConfiguration configuration, ICommonHelperService commonHelperService)
        {
            _configuration = configuration;
            _commonHelperService = commonHelperService;
        }
        public async Task<bool> SendMail(string fromMailAddress, string toMailAddress)
        {
            try
            {
                if (_commonHelperService.ValidateEmail(fromMailAddress) && _commonHelperService.ValidateEmail(toMailAddress))
                {
                    var apiKey = _configuration["SendGridApikey"];
                    var client = new SendGridClient(apiKey);
                    var from = new EmailAddress(fromMailAddress, "JJraj");
                    var subject = "Test Mail";
                    var to = new EmailAddress(toMailAddress, "Jothiraj");
                    var plainTextContent = "and easy to do anywhere, even with C#";
                    //var htmlContent = _commonHelperService.FormEmailBody() != null ? _commonHelperService.FormEmailBody() : "";
                    var htmlContent = _commonHelperService.FormEmailBody() != null ? _commonHelperService.FormEmailBody() : "";
                    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                    var response = await client.SendEmailAsync(msg);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
