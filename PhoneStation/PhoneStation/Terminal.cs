using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneStation
{
    public class Terminal:ITerminal
    {
        protected bool IsOnLine { get; private set; }

        public PhoneNumber Number { get; set; }

        public Terminal(PhoneNumber number)
        {
            this.Number = number;
        }

        //property of incoming Request
        private Request StationIncomingRequest { get; set; }

        public event EventHandler<Request> OutcomingCall;

        //EventHandler method for event OutcomingCall
        protected virtual void OnOutcomingCall(object sender, PhoneNumber target)
        {
            if (OutcomingCall != null)
            {
                StationIncomingRequest = new OutCallRequest() { Source = this.Number, Target = target };
                OutcomingCall(sender, StationIncomingRequest);
            }
        }

        public event EventHandler<OutCallRequest> IncomingRequest;

        //EventHandler method for event IncomingRequest
        protected virtual void OnIncomingRequest(object sender, OutCallRequest request)
        {
            if (IncomingRequest != null)
            {
                request.Target = this.Number;
                IncomingRequest(sender, request);
            }
            StationIncomingRequest = request;
        }

        public void IncomingRequestFrom(PhoneNumber source)
        {
            OnIncomingRequest(this, new OutCallRequest() { Source = source });
        }


        public event EventHandler<Respond> IncomingRespond;
        //EventHandler method for event IncomingRespond

        protected virtual void OnIncomingRespond(object sender, Respond respond)
        {
            if (this.IncomingRespond != null && StationIncomingRequest != null)
            {
                this.IncomingRespond(sender, respond);

            }
        }

        public event EventHandler OnlineMode;

        protected virtual void OnOnlineMode(object sender, EventArgs arg)
        {
            if (OnlineMode != null)
            {
                OnlineMode(sender, arg);

            }
            IsOnLine = true;
        }

        public event EventHandler OfflineMode;

        protected virtual void OnOfflineMode(object sender, EventArgs arg)
        {
            if (OfflineMode != null)
            {
                OfflineMode(sender, arg);
                StationIncomingRequest = null;
            }
            IsOnLine = false;
        }

        public event EventHandler Connected;

        protected virtual void OnConnected(object sender, EventArgs arg)
        {
            if (Connected != null)
            {
                Connected(sender, arg);
            }
        }

        public event EventHandler DisConnected;
        protected virtual void OnDisConnected(object sender, EventArgs arg)
        {
            if (DisConnected != null)
            {
                DisConnected(sender, arg);
            }
        }

        public void Call(PhoneNumber target)
        {
            if (!IsOnLine)
            {
                OnOnlineMode(this, null);
                OnOutcomingCall(this, target);

            }
        }

        public void Drop()
        {
            if (StationIncomingRequest != null)
            {
                OnIncomingRespond(this, new Respond() { Source = Number, State = RespondState.Drop, Request = StationIncomingRequest });
            }
            if (IsOnLine)
            {
                OnOfflineMode(this, null);

            }
        }

        public void Answer()
        {
            if (!IsOnLine && StationIncomingRequest != null)
            {
                OnOnlineMode(this, null);
                OnIncomingRespond(this, new Respond() { Source = Number, State = RespondState.Accept, Request = StationIncomingRequest });

            }
        }

        public void Connect()
        {
            OnConnected(this, null);
        }

        public void DisConnect()
        {
            Drop();
            OnDisConnected(this, null);
        }

        public virtual void RegisterEventHandlersForPort(Port port)
        {
            port.StateChanged += (sender, state) =>
            {
                if (IsOnLine && state == PortState.Free)
                {
                    this.OnOfflineMode(sender, null);
                }
            };
        }

        public void ClearEvents()
        {
            this.OutcomingCall = null;
            this.IncomingRequest = null;
            this.IncomingRespond = null;
            this.OnlineMode = null;
            this.OfflineMode = null;
            this.Connected = null;
            this.DisConnected = null;
        }
    }
}
