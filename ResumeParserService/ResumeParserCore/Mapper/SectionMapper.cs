using ResumeParserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResumeParserCore.Mapper
{
    public class SectionMapper : ISectionMapper
    {
        private readonly Dictionary<SectionType, List<string>> _keyWordRegistry = new Dictionary<SectionType, List<string>>
        {                        
            {SectionType.Education, new List<string> {"education", "study", "school","degree","institution", "academic", "qualification"}},
           // {SectionType.Courses, new List<string> {"coursework", "course"}},
            {SectionType.Summary, new List<string> {"summary","profile" , "career","professional"}},
            {SectionType.WorkExperience, new List<string> {"experience", "work", "employment"}},
            {SectionType.Projects, new List<string> {"project"}},
            {SectionType.Skills, new List<string> {"skill", "ability", "tool", "expertise", "areas", "skills set", "technical skills"}},
           // {SectionType.Awards, new List<string> {"award", "certification", "certificate"}}
            {SectionType.Personal, new List<string> {"contact"}},
        };

        public SectionType FindSectionTypeMatching(string input)
        {
           // input = input.Trim();
            input = string.Concat(input.Where(c => !char.IsWhiteSpace(c)));
            var type = 
                (from sectionType in _keyWordRegistry
                 where sectionType.Value.Any(input.Contains)
                 select sectionType.Key).FirstOrDefault();
            return type;
        }
    }
}
