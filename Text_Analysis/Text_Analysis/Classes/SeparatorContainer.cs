using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_Analysis
{
    public class SeparatorContainer
    {
        private string[] sentenceSeparators = new string[] {"...", "?!", ".", "?", "!" };
        private string[] wordSeparators = new string[] {" ", ","};

        public IEnumerable<string> SentenceSeparators()
        {
            return sentenceSeparators.AsEnumerable();
        }

        public IEnumerable<string> WordSeparators()
        {
            return wordSeparators.AsEnumerable();
        }

    }
}
