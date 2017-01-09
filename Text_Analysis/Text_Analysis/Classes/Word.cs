using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_Analysis
{
    public class Word : IWord
    {
        private Symbol[] symbols;

        public Word(string chars)
        {
            if (chars != null)
            {
                this.symbols = chars.Select(x => new Symbol(x)).ToArray();
            }
            else
            {
                this.symbols = null;
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
                StringBuilder sb = new StringBuilder();
                foreach (var s in this.symbols)
                {
                    sb.Append(s.Chars);
                }
                return sb.ToString(); 
            }

        }

        public bool IsFirstVowel
        {
            get
            {
                return "eyuioa".Contains(symbols[0].Chars.ToLower());
            }
        }
               
        public override bool Equals(object obj)
        {
            if (obj is Word)
            {
                return this.chars == ((Word)obj).chars;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return chars.GetHashCode();

        }
        public IEnumerator<Symbol> GetEnumerator()
        {
            return symbols.AsEnumerable().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.symbols.GetEnumerator();
        }


    }
}
