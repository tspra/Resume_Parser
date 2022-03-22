using ResumeParserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResumeParserCore.Parser
{
    public class SkillParser:IParser
    {
        public void Parse(Section section, ResumeDetails resume)
        {
         

            foreach (var line in section.Content)
            {
                // var indexOfColon = line.IndexOf(':');
                //var skills = indexOfColon > -1 ? line.Substring(indexOfColon + 1) : line;
                // var elements = skills.Split(',');
                //resume.Skills.AddRange(s.Select(e => e.Trim()));
                resume.Skills.Add(line);
            }
        }
    }
}
