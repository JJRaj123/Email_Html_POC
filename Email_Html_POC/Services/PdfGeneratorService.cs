using Aspose.Pdf;
using Email_Html_POC.Utilities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Email_Html_POC.Services
{
    public class PdfGeneratorService:IPdfGeneratorService
    {
        private readonly ICommonHelperService _commonHelperService;
        public PdfGeneratorService(ICommonHelperService commonHelperService)
        {
            _commonHelperService = commonHelperService;
        }
        public byte[] GeneratePdf()
        {
            try
            {
                return _commonHelperService.ConvertToPDF();
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
