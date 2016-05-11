using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhoneStation
{
    public class Request:EventArgs
    {
        public Terminal Target { get; set; }
        public Terminal Sourse { get; set; }
    }
}
