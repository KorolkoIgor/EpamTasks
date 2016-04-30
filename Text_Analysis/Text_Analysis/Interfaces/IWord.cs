﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_Analysis
{
    public interface IWord:ISentenceItem, IEnumerable<Symbol>
    {
        Symbol this[int index] { get; }
        bool IsFirstVowel { get; }
       
    }
}
