using ResumeParserCore.Helper;
using ResumeParserCore.Parser;
using ResumeParserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResumeParserCore.Builder
{
    public class ResumeBuilder : IResumeBuilder
    {
        private readonly Dictionary<SectionType, dynamic> _parserRegistry;
        public ResumeBuilder()
        {
            _parserRegistry = new Dictionary<SectionType, dynamic>
            {
                {SectionType.Personal, new PersonalParser()},
                {SectionType.Summary, new SummaryParser()},
              //  {SectionType.Education, new EducationParser()},
                {SectionType.Projects, new ProjectsParser()},
               // {SectionType.WorkExperience, new WorkExperienceParser(resourceLoader)},
                {SectionType.Skills, new SkillParser()},
               // {SectionType.Courses, new CoursesParser()},
                //{SectionType.Awards, new AwardsParser()}
            };
        }

        public Resume Build(IList<Section> sections)
        {
            var details = new ResumeDetails();

            foreach (var section in sections.Where(section => _parserRegistry.ContainsKey(section.Type)))
            {
                _parserRegistry[section.Type].Parse(section, details);
            }
            var  resume = new Resume();
            resume.Details = details;
            resume.Catagory = CatagoryMapper.FindCatagory(details);
            return resume;
        }
    }
}
