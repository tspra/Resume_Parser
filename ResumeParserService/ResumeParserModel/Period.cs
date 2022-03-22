﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ResumeParserModel
{
    public class Period
    {
        public string Start { get; private set; }
        public string End { get; private set; }

        public Period(string start, string end)
        {
            Start = start;
            End = end;
        }
    }
}
