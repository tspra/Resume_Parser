using ResumeParserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;


namespace ResumeParserCore.Parser
{
    public class PersonalParser : IParser
    {
        private static readonly Regex EmailRegex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex PhoneRegex = new Regex(@"(\(\+[0-9]{1,3}\)[\.\s]?)?[0-9]{7,14}(?:x.+)?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex SocialProfileRegex = new Regex(@"(http(s)?:\/\/)?([\w]+\.)?(linkedin\.com|facebook\.com|github\.com|stackoverflow\.com|bitbucket\.org|sourceforge\.net|(\w+\.)?codeplex\.com|code\.google\.com).*?(?=\s)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex SplitByWhiteSpaceRegex = new Regex(@"\s+|,", RegexOptions.Compiled);
    
        public void Parse(Section section, ResumeDetails resume)
        {
            var firstNameFound = false;
            var emailFound = false;
            var phoneFound = false;

            foreach (var line in section.Content)
            {
              
                firstNameFound = ExtractFirstAndLastName(resume, firstNameFound, line);

                emailFound = ExtractEmail(resume, emailFound, line);

                phoneFound = ExtractPhone(resume, phoneFound, line);

                ExtractSocialProfiles(resume, line);
            }
        }


        private void ExtractSocialProfiles(ResumeDetails resume, string line)
        {
            var socialProfileMatches = SocialProfileRegex.Matches(line);
            foreach (Match socialProfileMatch in socialProfileMatches)
            {
                resume.SocialProfiles.Add(socialProfileMatch.Value);
            }
        }

        private bool ExtractPhone(ResumeDetails resume, bool phoneFound, string line)
        {
            var input = string.Concat(line.Where(c => !char.IsWhiteSpace(c)));
            if (phoneFound) return phoneFound;

            var phoneMatch = PhoneRegex.Match(input);
            if (!phoneMatch.Success) return phoneFound;

            resume.PhoneNumbers = phoneMatch.Value;

            phoneFound = true;

            return phoneFound;
        }

        

        private bool ExtractFirstAndLastName(ResumeDetails resume, bool firstNameFound, string line)
        {
            var words = SplitByWhiteSpaceRegex.Split(line);

            if (firstNameFound) return firstNameFound;

            return firstNameFound;
        }

        private bool ExtractEmail(ResumeDetails resume, bool emailFound, string line)
        {
           var input = string.Concat(line.Where(c => !char.IsWhiteSpace(c)));
            if (emailFound) return emailFound;

            var emailMatch = EmailRegex.Match(input);
            if (!emailMatch.Success) return emailFound;

            resume.EmailAddress = emailMatch.Value;

            emailFound = true;

            return emailFound;
        }
    }
}
