using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStation
{
    public class TestPort:Port
    {

        public void OnOutgoingCall(object sender, Request request)
        {
            if (request.GetType() == typeof(OutCallRequest) && this.State == PortState.Free)
            {
                this.State = PortState.Busy;
            }
        }

        public override void RegisterEventHandlersForTerminal(ITerminal terminal)
        {
            terminal.OutcomingCall += this.OnOutgoingCall;
            terminal.Connected += (port, args) => { this.State = PortState.Free; };
            terminal.DisConnected += (port, args) => { this.State = PortState.UnPlugged; };
        }

        public TestPort()
        {
            this.StateChanged += (sender, state) => { Console.WriteLine("Port detected the State is changed to {0}", state); };
        }
    }
}
