using ResumeParserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeParserCore.Builder
{
    public interface IResumeBuilder
    {
        Resume Build(IList<Section> sections);
    }
}
