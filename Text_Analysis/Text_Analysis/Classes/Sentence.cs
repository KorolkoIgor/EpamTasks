using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Text_Analysis.Interfaces;


namespace Text_Analysis
{
    public class Sentence:ISentence
    {
        public IList<ISentenceItem> Items { get; set; }
        public Sentence()
        {
            Items = new List<ISentenceItem>();
        }

        public int Length
        {
            get
            {
                return Items.Count(x => x is IWord);
            }
        }
        public string GetSentence()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Items)
            {
                if (item.chars == ",")
                {
                    sb.Append(item.chars + " ");
                }
                else
                    sb.Append(item.chars);
            }
            return sb.ToString(); 
        }


        public IEnumerable<IWord> GetWordsByLength(int length)
        {
            return  Items.Where(x => x is IWord).Where(x => x.chars.Length == length).Cast<IWord>().ToList(); 
         
        }

        public  IEnumerable<ISentenceItem> RemoveAll(int length)
        {
            IList<ISentenceItem> NewSen = new List<ISentenceItem>();
            foreach (var item in Items)
            {
                if (!((item.chars.Length == length) && !((item as IWord).IsFirstVowel)))
                   
                NewSen.Add(item);
           }
            return Items = NewSen;
        }

        public IEnumerable<ISentenceItem> ReplaceWordsByLength(int length, string newWord)
        {
            for (int i = 0; i <= Items.Count() - 1; i++)
            {
                var word = Items[i] as IWord;

                if (word != null && word.chars.Length == length)
                {
                    Items[i] = new Word(newWord);
                }
            }
            Parser newParser = new Parser();
           Items = newParser.CreateSentence(GetSentence()).Items;
            
          return Items;
        }

        }
    }

