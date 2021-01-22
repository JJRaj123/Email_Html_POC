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
using System.Text;

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
                    //msg.AddBcc("jjeee20@gmail.com");
                    //msg.AddCc("jjeee20@gmail.com");
                    //string dataDir = Directory.GetCurrentDirectory();
                    //msg.AddAttachment("CheckDoc", dataDir + "\\html_test.PDF");
                    //msg.Personalizations[0].Bccs = new List<EmailAddress>();
                    //msg.Personalizations[0].Bccs.Add(new EmailAddress("jjeee20@gmail.com"));
                    msg.AddBcc(new EmailAddress("jmothiraj@worldbank.org", "bcc"));
                    msg.AddBcc(new EmailAddress("kmitaigiri@worldbank.org", "cc"));
                    ///Dynamically resolving the content and generate the pdf//
                    byte[] byteData =_commonHelperService.ConvertToPDF();
                    ///Can add multiple attachments but need to pass file type, file name, byte content//
                    msg.Attachments= new List<SendGrid.Helpers.Mail.Attachment>
                    {
                    new SendGrid.Helpers.Mail.Attachment
                    {
                        Content = Convert.ToBase64String(byteData),
                        Filename = "FILE_NAME.pdf",
                        Type = "application/pdf",
                        Disposition = "attachment"
                    }
                   };
                    var response = await client.SendEmailAsync(msg);
                    if (response.StatusCode >= System.Net.HttpStatusCode.BadRequest)
                    {
                        throw new Exception(response.StatusCode.ToString());
                    }
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
