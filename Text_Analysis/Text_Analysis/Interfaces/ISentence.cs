using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_Analysis.Interfaces
{
    public interface ISentence
    {
        IList<ISentenceItem> Items { get; }
        int Length{ get; }
        string GetSentence();
        IEnumerable<IWord> GetWordsByLength(int length);
        IEnumerable<ISentenceItem> RemoveAll(int length);
        IEnumerable<ISentenceItem> ReplaceWordsByLength(int length, string newWord);
    }
}
