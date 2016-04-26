using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Text_Analysis
{
    public class Text
    {
        private ICollection<Sentence> TextContainer{ get; set;}
        
         public Text()
        {
            TextContainer = new List<Sentence>();
        }
        
        
        public void Add(Sentence item)
        {
            TextContainer.Add(item);
        }
        public int Count
        {
            get
            {
                return TextContainer.Count;
            }
        }
       
        public string GetText()
        {
            string newText = "";
            foreach (var item in TextContainer)
            {
                newText += item.GetSentence() + " ";
            }
            return newText;
        }

        public List<Sentence> SortByLength()
        {

            IEnumerable<Sentence> query = from sentence in TextContainer
                                          orderby sentence.Length
                                          select sentence;
            return query.ToList();
        }


        public List<Sentence> GetByQuestionType()
        {
           IEnumerable<Sentence> query = from sentence in TextContainer
                                         where sentence.Items.Last().chars == "?"
                                         select sentence;
            return query.ToList();
        }

        public List<IWord> GetWordsByLengthInQuestionSentence(int length)
        {
            List<IWord> words = new List<IWord>();
            foreach (var item in GetByQuestionType())
            {
                foreach (var pp in item.GetWordsByLength(length))
                {
                    words.Add(pp);
                }
            }
            var yy = words.Distinct<IWord>().ToList();
            return yy;
        }

        //public List<ISentenceItem> GetWordsByLength(int length)
        //{
        //    List<ISentenceItem> words = new List<ISentenceItem>();
        //    foreach (var item in _textContainer)
        //    {
        //        words.AddRange(item.GetWordsByLength(length));
        //    }
        //   return words;
        //} 
        
        public Text RemoveWordsByLength(int length)
        {
            Text text = new Text();
            foreach (var item in TextContainer)
            {
                item.RemoveWordsByLength(length);
                text.Add(item);
            }
            return text;
        }

        public Sentence GetSentenceByIndex(int index)
        {
            var sentence = TextContainer.ElementAt(index);
            return sentence;
        }
    }
}
