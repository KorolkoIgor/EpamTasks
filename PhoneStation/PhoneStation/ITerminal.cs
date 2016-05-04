using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStation
{
    public interface ITerminal
    {
       PhoneNumber Number { get; }
       Contract Contract { get; }
       Port Link { get; }

      

        event EventHandler<Request> CallFrom;
        event EventHandler<RegisterTerminal> RegisterTerminal;
        event EventHandler AcceptCall;
        event EventHandler EndCall;

        void Call(Terminal target);
        void Answer();
        void Drop();
        void OnPort();
        bool IsPortOnStation();
        void ClearEvents();
       
    }
}
