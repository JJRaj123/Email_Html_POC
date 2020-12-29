using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Email_Html_POC.Services
{
    public interface IEmailNotificationService
    {
         Task<bool> SendMail(string fromMailAddress, string toMailAddress);
    }
}
