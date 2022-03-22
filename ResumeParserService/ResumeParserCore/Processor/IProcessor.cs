using ResumeParserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeParserCore.Processor
{
    public interface IProcessor 
    {
        Resume Process(string location);
    }
}
