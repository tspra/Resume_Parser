﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeParserCore.Reader
{
    public abstract class InputReaderBase : IInputReader
    {
        public IInputReader NextReader { get; set; }

        public IList<string> ReadIntoList(string location)
        {
            if (CanHandle(location))
            {
                return Handle(location);
            }

            if (NextReader != null)
            {
                return NextReader.ReadIntoList(location);
            }
            return null;
            //throw new NotSupportedResumeTypeException("No reader registered for this type of resume: " + location);
        }

        protected abstract bool CanHandle(string location);
        protected abstract IList<string> Handle(string location);
    }
}
