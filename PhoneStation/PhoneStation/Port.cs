using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneStation
{
    public class Port:IPort
    {
        private PortState _state = PortState.UnPlugged;

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

        public void RegisterEventHandlersForPort(Terminal terminal)
        {
          
            this.StateChanged += (sender, arg) =>
          {
              Console.WriteLine("Port terminal number {0} detected the State is changed to {1}",
                  terminal.Number, State);
          };
        }
        public void ClearEvents()
        {
            this.StateChanged = null;
        }
    }
}
