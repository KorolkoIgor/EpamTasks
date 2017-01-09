using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BL.DateParser
{
    public class CsvParser : DataParser
    {
        public string FilePath { get; set; }

        
        protected override Stream GetStream()
        {
            return new FileStream(FilePath, FileMode.Open);
        }

        public CsvParser(string filePath, char[] delimiter)
            : base(delimiter)
        {
            this.FilePath = filePath;
        }
    }
}
