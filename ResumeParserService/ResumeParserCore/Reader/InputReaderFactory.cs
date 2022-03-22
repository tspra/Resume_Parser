using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResumeParserCore.Reader
{
    public class InputReaderFactory : IInputReaderFactory
    {
        public IInputReader LoadInputReaders()
        {
            var parsers = new List<IInputReader>();
            parsers.Add(new DocInputReader() as IInputReader);
            parsers.Add(new DocxInputReader() as IInputReader);
            parsers.Add(new PdfInputReader() as IInputReader);

            if (!parsers.Any())
            {
                throw new ApplicationException("No parsers registered");
            }

            for (var i = 0; i < parsers.Count - 1; i++)
            {
                parsers[i].NextReader = parsers[i + 1];
            }

            return parsers[0];
        }
    }
}
