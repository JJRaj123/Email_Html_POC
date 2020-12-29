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
    public class PDFController : ControllerBase
    {
        private readonly IPdfGeneratorService _pdfGeneratorService;
        public PDFController(IPdfGeneratorService pdfGeneratorService)
        {
            _pdfGeneratorService = pdfGeneratorService;
        }
        [HttpGet]
        [Route("pdfgenerator")]
        public async Task<IActionResult> PDFGenerator()
        {
            return Ok(_pdfGeneratorService.GeneratePdf());
        }
    }
}
