using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeParserCore.Reader
{
    public interface IInputReader
    {
        IInputReader NextReader { get; set; }
        IList<string> ReadIntoList(string location);
    }
}
