using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;
using Aspose.Pdf;
using Email_Html_POC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Email_Html_POC.Utilities.Common
{
    public class CommonHelperService : ICommonHelperService
    {
        public bool ValidateEmail(string mail)
        {
            bool isEmail = Regex.IsMatch(mail, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return isEmail;
        }
        public string FormEmailBody()
        {
            try
            {
                string _template = "";
                string dataDir = Directory.GetCurrentDirectory(); 
                //HTML template document
                HTMLDocument templateHtml = new HTMLDocument(dataDir + "\\Utilities\\Templates\\" + "HTMLTemplateForJson.html");
                var _jsonData = JsonConvert.SerializeObject(GetStudentData());
                TemplateContentOptions _templateContent = new TemplateContentOptions(_jsonData,TemplateContent.JSON);
                TemplateData data = new TemplateData(_templateContent);
                //Merge HTML tempate with JSON data
                _template = Converter.ConvertTemplate( templateHtml, data, new TemplateLoadOptions())?.DocumentElement?.InnerHTML;
                return _template;
            }
            catch (Exception ex)
            {
                throw null;
            }
        }
        public MemoryStream ConvertToPDF()
        {
            string dataDir = Directory.GetCurrentDirectory();
            string _template = FormEmailBody();
            HtmlLoadOptions options = new HtmlLoadOptions();
            byte[] byteArray = Encoding.UTF8.GetBytes(_template);
            MemoryStream stream = new MemoryStream(byteArray);
            Document pdfDocument = new Document(stream,options);
            var outputFile = new MemoryStream();
            pdfDocument.Save(outputFile, SaveFormat.Pdf);
            return outputFile;
            //pdfDocument.Save(dataDir + "\\html_test.PDF",SaveFormat.Pdf);
            //pdfDocument.Save();
        }
        public Student GetStudentData()
        {
            List<Persons> _lstPerson = new List<Persons>() { new Persons { Address = new Address { City = "Tiruppur", Number = "147", Street = "Senthur nagar" }, Name = "JJraj", Surname = "Mothiraj" }, new Persons { Address = new Address { City = "Tiruppur", Number = "100", Street = "Velampalayam" }, Name = "Bala", Surname = "Arumugam" } };
            Student std = new Student() { Title = "Test Json", Persons = _lstPerson, Rating = 5 };
            return std;
        }
    }
}
