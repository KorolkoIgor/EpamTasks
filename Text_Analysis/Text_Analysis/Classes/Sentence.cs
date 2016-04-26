using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Text_Analysis
{
    public class Sentence
    {
        public List<ISentenceItem> Items { get; set; }
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
            string sentence = "";
            foreach (var item in Items)
            {
                if (item.chars == ",")
                { sentence += item.chars + " "; }
                else
                    sentence += item.chars;
            }
            return sentence;
        }

        public List<IWord> GetWordsByLength(int length)
        {
            var words = Items.Where(x => x is IWord);
            var tt = words.Where(x => x.chars.Length == length).Cast<IWord>();
           return tt.ToList();
        }

        public void RemoveWordsByLength(int length)
        {
            Items.RemoveAll(x => (x.chars.Length == length) && !((x as IWord).IsFirstVowel));

        }
              

        public void ReplaceWordsByLength(int length, string newWord)
        {
            for (int i = 0; i <= Items.Count() - 1; i++)
            {
                var word = Items[i] as IWord;

                if (word != null && word.chars.Length == length)
                {
                    Items[i] = new Word(newWord);
                }
            }
        }
    }
}
