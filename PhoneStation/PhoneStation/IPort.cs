using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneStation
{
    public interface IPort
    {
        PortState State { get; }
        event EventHandler StateChanged;
        void RegisterEventHandlersForPort(Terminal terminal);
        void ClearEvents();
    }
}
