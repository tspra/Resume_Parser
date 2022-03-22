using ResumeParserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeParserCore.Parser
{
    public class SummaryParser : IParser
    {
        public void Parse(Section section, ResumeDetails resume)
        {
            //resume.SummaryDescription = string.Join("; ", section.Content);
        }
    }
}
