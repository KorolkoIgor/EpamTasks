using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_Analysis
{
    public class Text
    {
        private ICollection<Sentence> _textContainer = new List<Sentence>();
        public void Add(Sentence item)
        {
            _textContainer.Add(item);
        }
        public int Count
        {
            get
            {
                return _textContainer.Count;
            }
        }
       
        public string GetText()
        {
            string newText = "";
            foreach (var item in _textContainer)
            {
                newText += item.GetSentence() + " ";
            }
            return newText;
        }

        public List<Sentence> SortByLength()
        {

            IEnumerable<Sentence> query = from sentence in _textContainer
                                          orderby sentence.Length
                                          select sentence;
            return query.ToList();
        }


        public List<Sentence> GetByQuestionType()
        {
           IEnumerable<Sentence> query = from sentence in _textContainer
                                         where sentence.Items.Last().chars == "?"
                                         select sentence;
            return query.ToList();
        }

        public List<Word> GetWordsByLengthInQuestionSentence(int length)
        {
            List<Word> words = new List<Word>();
            foreach (var item in GetByQuestionType())
            {
                foreach (var pp in item.GetWordsByLength(length))
                {
                    words.Add(pp);
                }
            }
            var yy = words.Distinct<Word>().ToList();
            return yy;
        }

        public List<ISentenceItem> GetWordsByLength(int length)
        {
            List<ISentenceItem> words = new List<ISentenceItem>();
            foreach (var item in _textContainer)
            {
                words.AddRange(item.GetWordsByLength(length));
            }
            words.Distinct();
            return words;
        }
        
        public Text RemoveWordsByLength(int length)
        {
            Text text = new Text();
            foreach (var item in _textContainer)
            {
                item.RemoveWordsByLength(length);
                text.Add(item);
            }
            return text;
        }

        public Sentence GetSentenceByIndex(int index)
        {
            var sentence = _textContainer.ElementAt(index);
            return sentence;
        }
    }
}
