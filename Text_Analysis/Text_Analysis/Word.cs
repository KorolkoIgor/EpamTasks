﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_Analysis
{
    public class Word:IWord
    {
        private Symbol[] symbols;

        public Word(string chars)
        {
            if (chars != null)
            {
                this.symbols = chars.Select(x => new Symbol(x)).ToArray();
            }
        }

        public Symbol this[int index]
        {
            get
            {
                return symbols[index];
            }
        }

        public string chars
        {
            get
            {
                string word = "";
                foreach (var item in symbols)
                {
                    word += item.Chars;
                }
                return word;
            }
        }

     
        public bool IsFirstVowel
        {
            get
            {
                return "eyuioa".Contains(symbols[0].Chars.ToLower());
            }
        }
    }
}
