using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ResumeParserCore.Reader
{
    public class PdfInputReader : InputReaderBase
    {
        protected override bool CanHandle(string location)
        {

            FileInfo fi = new FileInfo(location);
            // Get file extension   
            string extn = fi.Extension.ToLower();
            return  extn.Equals(".pdf");
        }

        protected override IList<string> Handle(string location)
        {
            var lines = new List<string>();

            if (!File.Exists(location))
            {
                throw new ArgumentException("File not exists: " + location);
            }

            using (var pdfReader = new PdfReader(location))
            {
                for (var page = 1; page <= pdfReader.NumberOfPages; page++)
                {
                    var strategy = new SimpleTextExtractionStrategy();
                    var currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);

                    currentText = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                    lines.AddRange(currentText.Split(new[] { "\n" }, StringSplitOptions.None));
                }
            }

            return lines;
        }
    }
}
