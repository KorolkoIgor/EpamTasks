using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.IO;


namespace BL.DateParser
{
    public abstract class DataParser
    {
        protected char[] Delimiter { get; set; }
        protected Stream Source { get; set; }

        public DataParser(char[] delimiter)
        {
            Delimiter = delimiter;
        }

        public IEnumerable<string[]> GetRecords()
        {
                this.Source = GetStream();
                using (StreamReader reader = new StreamReader(Source))
                {
                    while (!reader.EndOfStream)
                    {
                        yield return reader.ReadLine().Split(Delimiter, StringSplitOptions.None);
                    }
                }
        }

        protected abstract Stream GetStream();
    }
}
