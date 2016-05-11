using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneStation
{
    public class Port:IPort
    {
        private PortState _state;

        public PortState State
        {
            get
            {
                return _state;
            }
            set
            {
                if (_state != value)
                    _state = value;
                OnStateChanged(this, null);
            }
        }

        public Port(Terminal terminal)
        {
            this.StateChanged += (sender, arg) =>
            {
                Console.WriteLine("Port terminal number {0} detected the State is changed to {1}",
                    terminal.Number, State);
            };
            State = PortState.UnPlugged;
            RegisterEventHandlersForTerminal(terminal);
        }

        public event EventHandler StateChanged;

        protected virtual void OnStateChanged(object sender, EventArgs arg)
        {
            var temp = StateChanged;
            if (temp != null)
            {
                temp(sender, arg);
            }
            else
                Console.WriteLine("To port is not connected terminal!");
        }

        public void RegisterEventHandlersForTerminal(ITerminal terminal)
        {
            terminal.Connected += (port, args) =>
            {
                Console.WriteLine("Terminal {0} plug to port", terminal.Number);
                this.State = PortState.Free;
            };
            //terminal.DisConnected += (port, args) =>
            //{
            //    Console.WriteLine("Terminal {0} unplug to port", terminal.Number);
            //    this.State = PortState.UnPlugged;
            //};
        }
        public void ClearEvents()
        {
            this.StateChanged = null;
        }
    }
}
