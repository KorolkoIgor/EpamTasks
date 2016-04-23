using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_Analysis
{
    public class Punctuation:IPunctuation
    {
        private Symbol[] value;
        public Symbol[] Value
        {
            get
            {
                return value;
            }
        }
        
        public Punctuation(string chars)
        {
            if (chars != null)
            {
                this.value = chars.Select(x => new Symbol(x)).ToArray();
            }
        }

        public string chars
        {
            get
            {
                string punctuatonMark = "";
                foreach (var item in Value)
                {
                    punctuatonMark += item.Chars;
                }
                return punctuatonMark;
            }
        }

    }
}
