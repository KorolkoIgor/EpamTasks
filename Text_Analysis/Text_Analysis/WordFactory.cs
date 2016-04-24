using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_Analysis
{
    public class WordFactory:ISentenceItemFactory
    {
        public ISentenceItem Create(string chars)
        {
            return new Word(chars);
        }
      
    }
}
