using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneStation
{
    public interface IStation
    {
       ICollection<Port> Ports { get;}
       
        event EventHandler<CallHistory> CallHistoryCreated;
        
        Port AddPort(Terminal terminal);
        void RemovePort(Terminal terminal);
        void TerminalRegister(object sender, EventArgs arg);
        void TerminalCall(object sender, Request request);
        void TerminalAnswer(object sender, EventArgs arg);
        void TerminalEndCall(object sender, EventArgs arg);
        void ClearEvents();



    }
}
