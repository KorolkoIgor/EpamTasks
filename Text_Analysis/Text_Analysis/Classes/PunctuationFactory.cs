using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_Analysis
{
    public class PunctuationFactory : ISentenceItemFactory
    {
        public ISentenceItem Create(string chars)
        {
            return new Punctuation(chars);
        }
    }
}
