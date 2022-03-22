using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeParserCore.Reader
{
    public interface IInputReaderFactory
    {
        IInputReader LoadInputReaders();
    }
}
