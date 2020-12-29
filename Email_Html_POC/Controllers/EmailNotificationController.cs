using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Email_Html_POC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Email_Html_POC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailNotificationController : ControllerBase
    {
        private readonly IEmailNotificationService _emailNotificationService;        
        public EmailNotificationController(IEmailNotificationService emailNotificationService)
        {
            _emailNotificationService = emailNotificationService;
        }
        [HttpGet]
        [Route("sendmail")]
        public async Task<IActionResult> SendMail(string fromMailAddress,string toMailAddress)
        {
            return Ok(_emailNotificationService.SendMail(fromMailAddress,toMailAddress));
        }
    }
}
