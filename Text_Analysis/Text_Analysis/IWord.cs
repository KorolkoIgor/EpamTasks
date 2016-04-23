using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_Analysis
{
    public interface IWord:ISentenceItem
    {
        Symbol this[int index] { get; }

        string chars { get; }
        bool IsFirstVowel { get; }
       
    }
}
