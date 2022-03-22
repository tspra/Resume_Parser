using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ResumeParserCore.Reader
{
    class DocxInputReader : InputReaderBase
    {
        protected override bool CanHandle(string location)
        {
           // return location.EndsWith("docx");
            FileInfo fi = new FileInfo(location);
            // Get file extension   
            string extn = fi.Extension.ToLower();
            return extn.Equals(".docx");
        }

        protected override IList<string> Handle(string location)
        {
            var lines = new List<string>();

            using (var wordDoc = WordprocessingDocument.Open(location, false))
            {
                var paragraphElements = wordDoc.MainDocumentPart.Document.Body.Descendants<Paragraph>();

                lines.AddRange(paragraphElements.Select(p =>
                    p.Descendants<Text>())
                        .Select(textElements => string.Join("", textElements.Select(t => t.Text))));
            }

            return lines;
        }
    }
}
