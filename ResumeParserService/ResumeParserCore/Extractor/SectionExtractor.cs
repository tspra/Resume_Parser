using ResumeParserCore.Mapper;
using ResumeParserModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ResumeParserCore.Extractor
{
    public class SectionExtractor : ISectionExtractor
    {
        private const int SectionTitleNumberOfWordsLimit = 6;
        private static readonly Regex SplitByWhiteSpaceRegex = new Regex(@"\s+", RegexOptions.Compiled);
        private readonly ISectionMapper _mapper;

        public SectionExtractor(ISectionMapper sectionMapper)
        {
            _mapper = sectionMapper;
        }
        public IList<Section> ExtractFrom(IList<string> rawInput)
        {
            var sections = new List<Section>();

            var i = 0;

            if (rawInput != null)
            {
                //Assume personal information always at the top
                var personalSection = new Section
                {
                    Type = SectionType.Personal
                };

                while (i < rawInput.Count - 1 &&
                       FindSectionType(rawInput[i].ToLower()) == SectionType.Unknown)
                {
                    if (!string.IsNullOrWhiteSpace(rawInput[i]))
                    {
                        personalSection.Content.Add(rawInput[i]);
                    }

                    i++;
                }

                sections.Add(personalSection);

                while (i < rawInput.Count)
                {
                    var input = rawInput[i].ToLower();
                    var sectionType = FindSectionType(input);
                    if (sectionType != SectionType.Unknown)
                    {
                        //Starting of a new section
                        var section = new Section
                        {
                            Type = sectionType
                        };

                        while (i < rawInput.Count - 1 &&
                            FindSectionType(rawInput[i + 1].ToLower()) == SectionType.Unknown)
                        {
                            i++;

                            if (!string.IsNullOrWhiteSpace(rawInput[i]))
                            {
                                section.Content.Add(rawInput[i]);
                            }
                        }

                        sections.Add(section);
                    }

                    i++;
                }

            }
            return sections;
        }
        private SectionType FindSectionType(string input)
        {
            var elements = SplitByWhiteSpaceRegex.Split(input);
            //var sectionType= elements.Length < SectionTitleNumberOfWordsLimit ? _mapper.FindSectionTypeMatching(input) : SectionType.Unknown;
            var sectionType = _mapper.FindSectionTypeMatching(input);
            return sectionType;
        }
    }
}
