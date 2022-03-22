using ResumeParserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeParserCore.Mapper
{
    public interface ISectionMapper
    {
        SectionType FindSectionTypeMatching(string input);
    }
}
