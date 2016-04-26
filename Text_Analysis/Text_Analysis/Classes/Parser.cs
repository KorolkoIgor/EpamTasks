using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Text_Analysis
{
    public class Parser
    {
        private SeparatorContainer separators = new SeparatorContainer();

        private WordFactory wordFactory = new WordFactory();
        private PunctuationFactory punctuationFactory = new PunctuationFactory();
     
        public Text Parse(string path)
        {
            Text resultText = new Text();
            var sentenceSeparators = separators.SentenceSeparators();
           
            StringBuilder buffer = new StringBuilder();
            buffer.Clear();
            try
            {
                using (StreamReader text = new StreamReader(path))
                {
                    string currentText = text.ReadLine();

                    while (currentText != "")
                    {
                        int sentenceSeparatorIndex = -1;
                        int sentenceSeparatorIndex1 = 1000;
                        string firstSentenceSeparator = null;

                        foreach (var s in sentenceSeparators)
                        {
                            int a = currentText.IndexOf(s);
                            if (a >= 0)
                            {
                                sentenceSeparatorIndex = currentText.IndexOf(s);
                            }
                            if (sentenceSeparatorIndex >= 0 && sentenceSeparatorIndex1 > sentenceSeparatorIndex)
                            {
                                sentenceSeparatorIndex1 = sentenceSeparatorIndex;
                                firstSentenceSeparator = s;
                            }
                        }


                        // string firstSentenceSeparator = sentenceSeparators.FirstOrDefault(x =>
                        //{
                        //    sentenceSeparatorIndex = currentText.IndexOf(x);
                        //    return sentenceSeparatorIndex >= 0;
                        //});

                        if (firstSentenceSeparator != null)
                        {
                            buffer.Append(currentText.Substring(0, sentenceSeparatorIndex1 + firstSentenceSeparator.Length));
                            Sentence newSentence = CreateSentence(buffer.ToString());
                            resultText.Add(newSentence);
                            buffer.Clear();
                            currentText = currentText.Remove(0, sentenceSeparatorIndex1 + firstSentenceSeparator.Length);

                            if (currentText != "")
                            {
                                currentText = currentText.Remove(0, 1);
                            }

                            else
                                if (text.ReadLine() != null)
                                {
                                    currentText = currentText + text.ReadLine();
                                    currentText = currentText.Remove(0, 1);
                                }
                        }
                        else
                        {
                            currentText = currentText + text.ReadLine();
                        }
                    }

                }
              
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            
            return resultText;

        }

      
        public Sentence CreateSentence(string sourse)
        {
            Sentence newSentence = new Sentence();
            var wordSeparators = separators.WordSeparators().Concat(separators.SentenceSeparators());
           
            string pattern = "\\s+"; 
            string patternOne = "\\t+"; 
            string replacement = " ";

            Regex gaps = new Regex(pattern);
            Regex tab = new Regex(patternOne);

            string result = gaps.Replace(sourse, replacement);
            string finall = tab.Replace(result, replacement);



            
            bool tr = true;

            while (tr == true)
            {
                tr = false;
                int punctuationMarkIndex = -1;
                int punctuationMarkIndex1 = 1000;
                string punctuationMark = null;

                foreach (var k in wordSeparators)
                {
                    int b = finall.IndexOf(k);
                    if (b >= 0)
                    {
                        punctuationMarkIndex = finall.IndexOf(k);
                    }
                   
                    if (punctuationMarkIndex >= 0 && punctuationMarkIndex1 > punctuationMarkIndex)
                    {
                        punctuationMarkIndex1 = punctuationMarkIndex;
                        punctuationMark = k;
                    }
                }
                
                //string punctuationMark = wordSeparators.FirstOrDefault(x =>
                //{
                //    punctuationMarkIndex = sourse.IndexOf(x);
                //    return punctuationMarkIndex >= 0;
                //});

                if (punctuationMark != null)
                {
                    newSentence.Items.Add(wordFactory.Create(finall.Substring(0, punctuationMarkIndex1)));

                    newSentence.Items.Add(punctuationFactory.Create(finall.Substring(punctuationMarkIndex1, punctuationMark.Length)));
                    finall = finall.Remove(0, punctuationMarkIndex1 + punctuationMark.Length);
                    tr = true;

                    if (punctuationMark == ",")
                    {
                        finall = finall.Remove(0, 1);
                    }
                }
            }
            return newSentence;
        }
    }
}
