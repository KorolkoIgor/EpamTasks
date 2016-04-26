using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_Analysis
{
   public  interface ISentenceItemFactory
    {
       ISentenceItem Create(string chars);
    }
}
