using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace Text_Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Text presentText = new Text();
            var readpath = ConfigurationManager.AppSettings["PathToReadFile"];
            var writepath = ConfigurationManager.AppSettings["PathToWriteFile"];  
            Parser newParser = new Parser();
            
            try
            {
                presentText = newParser.Parse(readpath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(presentText.GetText());
            Console.ReadLine();
            
            //Sorted text by sentence words
            var sortedText = presentText.SortByLength();
            foreach (var item in sortedText)
            {
                Console.WriteLine(item.GetSentence());
            }
            Console.ReadLine();
            
            //Get question sentences 
            var questionSentence = presentText.GetByQuestionType();
            foreach (var item in questionSentence)
            {
                Console.WriteLine(item.GetSentence());
            }
            Console.ReadLine();
            
            //In question sentences print words of a given length 
            foreach (var t in presentText.GetWordsByLengthInQuestionSentence(2))
            {
                Console.WriteLine(t.chars);
            }
            Console.ReadLine();

            //remove words by lenght 7 begins with a consonant
            Text text = presentText.RemoveWordsByLength(7);
            Console.WriteLine(text.GetText());
            Console.ReadLine();

            //replace  word by lenght 9 in 4 sentence in substring"6868 iii ddd kkkkkk!"
            Console.WriteLine(presentText.GetSentenceByIndex(4).GetSentence());
            presentText.GetSentenceByIndex(4).ReplaceWordsByLength(9, "6868 iii ddd kkkkkk");
            Console.WriteLine(presentText.GetSentenceByIndex(4).GetSentence());
            try
            {
                presentText.SaveTextToFile(writepath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           Console.ReadLine();
        }
    }
}
