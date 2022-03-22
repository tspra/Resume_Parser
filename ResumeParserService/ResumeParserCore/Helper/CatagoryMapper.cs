using ResumeParserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResumeParserCore.Helper
{
    public static class CatagoryMapper
    {

        private static readonly Dictionary<Catagory, List<string>> catagoryRegistery = new Dictionary<Catagory, List<string>>
        {
            {Catagory.Net, new List<string> {"C#", "c#", ".net",".Net","ASP.Net"}},
             {Catagory.Java, new List<string> {"JAVA","java"}},
              {Catagory.Cloud, new List<string> {"Azure", "Aws", "AWS","GCP"}},
               {Catagory.FullStack, new List<string> {"C#", "Angular", "React","Vue",}},
        };
        public  static Catagory FindCatagory(ResumeDetails details)
        {
            var type =
                (from sectionType in catagoryRegistery
                 where sectionType.Value.Any(s => details.Skills.Any())
                 select sectionType.Key).FirstOrDefault();
            return type;
        }
    }
}
