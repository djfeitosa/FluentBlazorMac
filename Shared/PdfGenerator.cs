using iTextSharp.text;
using iTextSharp.text.pdf;

namespace FluentBlazorMac.Shared
{
    public class PdfGenerator
    {
        public static void GeneratePdf(string fileName, string title, string body)
        {
            //Create a new document
            Document document = new();

            //Create a PDF writer
            PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));

            //Open the document
            document.Open();

            //Add a title
            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
            Paragraph titleParagraph = new(title, titleFont)
            {
                Alignment = Element.ALIGN_CENTER
            };
            document.Add(titleParagraph);

            //Add some text
            Font bodyFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            Paragraph bodyParagraph = new Paragraph(body, bodyFont);
            bodyParagraph.Alignment = Element.ALIGN_JUSTIFIED;
            document.Add(bodyParagraph);

            //Close the document
            document.Close();
        }

        public static byte[] GerarPdf()
        {
            var title = "Título";
            var body = "Tenho ainda muita coisa para desenvolver";
            var document = new Document();
            var stream = new MemoryStream();
            PdfWriter.GetInstance(document, stream);
            document.Open();
            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
            Paragraph titleParagraph = new(title, titleFont)
            {
                Alignment = Element.ALIGN_CENTER
            };
            document.Add(titleParagraph);

            Font bodyFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            Paragraph bodyParagraph = new(body, bodyFont)
            {
                Alignment = Element.ALIGN_JUSTIFIED
            };
            document.Add(titleParagraph);

            document.Close();
            var content = stream.ToArray();
            return content;
        }
    }
}