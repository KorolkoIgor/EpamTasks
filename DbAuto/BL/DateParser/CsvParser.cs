using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.DateParser
{
    public class CsvParser : DataParser
    {
        public string FilePath { get; set; }

        protected override System.IO.Stream GetStream()
        {
            return new System.IO.FileStream(FilePath, System.IO.FileMode.Open);
        }

        public CsvParser(string filePath, char[] delimiter)
            : base(delimiter)
        {
            this.FilePath = filePath;
        }
    }
}
