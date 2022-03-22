using ResumeParserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeParserCore.Parser
{
    public interface IParser
    {
        void Parse(Section section, ResumeDetails resume);
    }
}
