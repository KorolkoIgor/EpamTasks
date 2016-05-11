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
    


        event EventHandler Connected;
        event EventHandler<Request> CallFrom;
        event EventHandler RegisterTerminal;
        event EventHandler AcceptCall;
        event EventHandler EndCall;

        void Call(Terminal target);
        void Answer();
        void Drop();
        void Connect();
        bool IsPortOnStation();
        void ClearEvents();
       
    }
}
