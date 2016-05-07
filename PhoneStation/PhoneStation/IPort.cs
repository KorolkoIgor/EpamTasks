using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneStation
{
    public interface IPort
    {
        PortState State { get; set; }

       
        event EventHandler<PortState> StateChanged;

        void RegisterEventHandlersForTerminal(ITerminal terminal);
    }
}
