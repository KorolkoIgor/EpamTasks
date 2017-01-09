using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_Analysis
{
    public class Punctuation : IPunctuation
    {
        private Symbol value;

        public Symbol Value
        {
            get
            {
                return value;
            }
        }

        public Punctuation(string chars)
        {
            this.value = new Symbol(chars);
        }

         public string chars
        {
            get { return this.Value.Chars; }
        }

    }
       
    
}
