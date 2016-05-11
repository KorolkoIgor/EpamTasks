using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneStation
{
    public class CallHistory:EventArgs
    {
        public Terminal Source { get; set; }
        public Terminal Target { get; set; }
        public DateTime StartCall { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
