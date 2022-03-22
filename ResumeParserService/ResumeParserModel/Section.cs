using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeParserModel
{
    public enum SectionType
    {
        Unknown,
        Personal,
        Summary,
        Education,
        WorkExperience,
        Projects,
        Skills,
        Courses,
        Awards
    }
    public class Section
    {
        public SectionType Type { get; set; }
        public List<string> Content { get; set; }

        public Section()
        {
            Content = new List<string>();
        }
    }
}
