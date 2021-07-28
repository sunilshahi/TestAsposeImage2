using Aspose.Words;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.IO;

namespace TestAsposeImage2.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }
        public ActionResult OnGet()
        {
            var document = new Document("testfile.docx");
            var ms = new MemoryStream();
            document.Save(ms, SaveFormat.Pdf);
            return File(ms.ToArray(), "application/octet-stream", "testfile.pdf");
        }
    }
}
