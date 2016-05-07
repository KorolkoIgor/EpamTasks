using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneStation
{
    public abstract class Port:IPort
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
                    OnStateChanged(this, value);
                _state = value;

            }
        }

        public event EventHandler<PortState> StateChanged;

        protected virtual void OnStateChanged(object sender, PortState state)
        {
            if (StateChanged != null)
            {
                StateChanged(sender, state);
            }
        }

        public abstract void RegisterEventHandlersForTerminal(ITerminal terminal);
       
        public Port()
        {
            this.StateChanged += (sender, state) => { Console.WriteLine("Port detected the State is changed to {0}", state); };
        }

        public void ClearEvents()
        {
            this.StateChanged = null;

        }

    }
}
