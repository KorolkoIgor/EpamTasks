using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneStation
{
    public interface IStation
    {
        event EventHandler<CallHistory> CallHistoryCreated;

        void AddTerminal(Terminal terminal);
        void RegisterEventHandlersForTerminal(Terminal terminal);
        void ActivateTerminal(Terminal terminal);
        void DisActivateTerminal(Terminal terminal);
        void RemoveTerminal(Terminal terminal);

        bool GetPortByTerminal(Terminal terminal);
        Terminal GetTerminalByPhoneNumber(PhoneNumber number);

        void TerminalCall(object sender, Request request);
        void TerminalAnswer(object sender, EventArgs arg);
        void TerminalEndCall(object sender, EventArgs arg);
        void ClearEvents();



    }
}
