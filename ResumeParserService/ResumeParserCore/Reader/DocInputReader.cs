using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ResumeParserCore.Reader
{
    public class DocInputReader : InputReaderBase
    {
        protected override bool CanHandle(string location)
        {
           // return location.EndsWith("doc");
            FileInfo fi = new FileInfo(location);
            // Get file extension   
            string extn = fi.Extension.ToLower();
            return extn.Equals(".doc");
        }

        protected override IList<string> Handle(string location)
        {
            var word = new Microsoft.Office.Interop.Word.Application();
            object miss = System.Reflection.Missing.Value;
            object path = location;
            object readOnly = true;

            var doc = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss,
                ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);


            var lines = doc.Paragraphs.Cast<object>().Select((t, i) => doc.Paragraphs[i + 1].Range.Text).ToList();

            doc.Close();
            word.Quit();

            return lines;
        }
    }
}

