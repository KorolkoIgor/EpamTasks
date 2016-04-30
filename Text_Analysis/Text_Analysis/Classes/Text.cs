using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Text_Analysis.Interfaces;

namespace Text_Analysis
{
    public class Text
    {
        private ICollection<ISentence> TextContainer { get; set; }
        
         public Text()
        {
            TextContainer = new List<ISentence>();
        }
  
        public void Add(ISentence item)
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
            StringBuilder sb = new StringBuilder();
            foreach (var item in TextContainer)
            {
                     sb.Append(item.GetSentence()+" ");
            }
            return sb.ToString(); 
        }

        public void SaveTextToFile(string textpath)
        {
            
            using (StreamWriter sw = new StreamWriter(textpath, false))
            {
                foreach (var item in TextContainer)
                  
                    sw.WriteLine(item.GetSentence());
             }
         }
        
        public IEnumerable<ISentence> SortByLength()
        {

            IEnumerable<ISentence> query = from sentence in TextContainer
                                          orderby sentence.Length
                                          select sentence;
            return query.ToList();
        }

        public List<ISentence> GetByQuestionType()
        {
           var qu = new Punctuation("?");
           IEnumerable<ISentence> query = from sentence in TextContainer
                                         where sentence.Items.Last().chars == qu.chars
                                         select sentence;
            return query.ToList();
        }
        
        public IEnumerable<IWord> GetWordsByLengthInQuestionSentence(int length)
        {
           return  GetByQuestionType().SelectMany(x => x.GetWordsByLength(length)).Distinct<IWord>().ToList();
        }

        public Text RemoveWordsByLength(int length)
        {
            Text text = new Text();
            foreach (var item in TextContainer)
            {
                item.RemoveAll(length);
                text.Add(item);
            }
            return text;
        }

        public ISentence GetSentenceByIndex(int index)
        {
            var sentence = TextContainer.ElementAt(index);
            return sentence;
        }
    }
}
