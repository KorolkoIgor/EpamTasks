﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_Analysis
{
    public struct  Symbol
    {
        private string chars;
        
        public string Chars
        {
            get { return chars; }
            private set { chars = value; }
        }

        public Symbol(char source)
        {
            this.chars = String.Format("{0}", source);
        }

    }
}
