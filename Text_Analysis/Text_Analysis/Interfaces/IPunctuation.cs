using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_Analysis
{
    public interface IPunctuation:ISentenceItem
    {
        Symbol Value { get; }
    }
}
