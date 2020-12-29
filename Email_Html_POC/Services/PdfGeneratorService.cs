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
        public bool GeneratePdf()
        {
            try
            {
                MemoryStream _doc= _commonHelperService.ConvertToPDF();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
