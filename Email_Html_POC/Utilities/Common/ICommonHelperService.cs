using Aspose.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Email_Html_POC.Utilities.Common
{
    public interface ICommonHelperService
    {
        bool ValidateEmail(string mail);
        string FormEmailBody();
        byte[] ConvertToPDF();
    }
}
