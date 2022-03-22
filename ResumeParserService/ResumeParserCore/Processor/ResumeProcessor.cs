using ResumeParserCore.Builder;
using ResumeParserCore.Extractor;
using ResumeParserCore.Reader;
using ResumeParserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeParserCore.Processor
{
    public class ResumeProcessor : IProcessor
    {
       
        private readonly IInputReader _inputReaders;
        private readonly ISectionExtractor _sectionExtractor;
        private readonly IResumeBuilder _resumeBuilder;
        public ResumeProcessor(IInputReaderFactory factory,ISectionExtractor sectionExtractor,IResumeBuilder resumeBuilder)
        {
            _sectionExtractor = sectionExtractor;
            _inputReaders = factory.LoadInputReaders();
            _resumeBuilder = resumeBuilder;
        }
        public Resume Process(string location)
        {
            var rawInput = _inputReaders.ReadIntoList(location);
            var sections = _sectionExtractor.ExtractFrom(rawInput);
            var resume = _resumeBuilder.Build(sections);
            return resume;
        }
    }
}
