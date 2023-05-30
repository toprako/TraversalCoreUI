using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreUI.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            PdfPTable pdfPTable = new PdfPTable(3);
            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soyadı");
            pdfPTable.AddCell("Misafir TC");

            pdfPTable.AddCell("Eylül");
            pdfPTable.AddCell("YüceDağ");
            pdfPTable.AddCell("11111111111");

            pdfPTable.AddCell("Ali");
            pdfPTable.AddCell("Veli");
            pdfPTable.AddCell("13141111111");

            pdfPTable.AddCell("Kemal");
            pdfPTable.AddCell("Yıldırım");
            pdfPTable.AddCell("11111114511");

            pdfPTable.AddCell("Kemal");
            pdfPTable.AddCell("Yüce");
            pdfPTable.AddCell("11110001111");
            document.Add(pdfPTable);
            document.Close();

            return File("/pdfreports/dosya.pdf", "application/pdf", "dosya.pdf");
        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            PdfPTable pdfPTable = new PdfPTable(3);
            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soyadı");
            pdfPTable.AddCell("Misafir TC");

            pdfPTable.AddCell("Eylül");
            pdfPTable.AddCell("YüceDağ");
            pdfPTable.AddCell("11111111111");

            pdfPTable.AddCell("Ali");
            pdfPTable.AddCell("Veli");
            pdfPTable.AddCell("13141111111");

            pdfPTable.AddCell("Kemal");
            pdfPTable.AddCell("Yıldırım");
            pdfPTable.AddCell("11111114511");

            pdfPTable.AddCell("Kemal");
            pdfPTable.AddCell("Yüce");
            pdfPTable.AddCell("11110001111");
            document.Add(pdfPTable);
            document.Close();

            return File("/pdfreports/dosya.pdf", "application/pdf", "dosya.pdf");
        }
    }
}
