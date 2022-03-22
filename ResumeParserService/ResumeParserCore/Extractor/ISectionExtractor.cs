using ResumeParserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeParserCore.Extractor
{
    public interface ISectionExtractor
    {
        public IList<Section> ExtractFrom(IList<string> rawInput);
    }
}
