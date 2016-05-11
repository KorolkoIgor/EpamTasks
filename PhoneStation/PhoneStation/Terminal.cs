using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneStation
{
    public class Terminal:ITerminal
    {
        public PhoneNumber Number { get; set; }
        public PhoneNumber IncomingNumber { get; set; }
      
        public CallHistory callHistory;
 

        public Terminal(PhoneNumber abonentNumber, Station station)   
        {
            Number = abonentNumber;
         
            RegisterTerminal += station.TerminalRegister;
           
           if (IsPortOnStation())
            {
                CallFrom += station.TerminalCall;
                AcceptCall += station.TerminalAnswer;
                EndCall += station.TerminalEndCall;
            }
        }

        public event EventHandler<Request> CallFrom;

        protected virtual void OnCallFrom(object sender, Request request)
        {
            var temp = CallFrom;

            if (temp != null)
            {
                temp(sender, request);
            }

            else
                Console.WriteLine("Terminal is not connected station!");
        }


        public event EventHandler RegisterTerminal;

        protected virtual void OnRegisterTerminal(object sender, EventArgs arg)
        {
            var temp = RegisterTerminal;

            if (temp != null)
            {
                temp(sender, arg);
            }

            else
                Console.WriteLine("Terminal is not registered!");
        }

        public event EventHandler AcceptCall;

        protected virtual void OnAcceptCall(object sender, EventArgs arg)
        {
            var temp = AcceptCall;

            if (temp != null)
            {
                temp(sender, arg);
            }

            else
                Console.WriteLine("Terminal is not connected station!");
        }

        public event EventHandler EndCall;

        protected virtual void OnEndCall(object sender, EventArgs arg)
        {
            var temp = EndCall;

            if (temp != null)
            {
                temp(sender, arg);
            }

            else
                Console.WriteLine("Terminal is not connected station!");
        }


        public void Call(Terminal target)
        {
                Request request = new Request() { Target = target, Sourse= this };
                Console.WriteLine("Terminal number: {0}  calls to the number: {1}",
                          Number, target.Number);
                    OnCallFrom(this, request);
        }

        public void Answer()
        {
           OnAcceptCall(this, null);
        }

        public void Drop()
        {
            OnEndCall(this, null);
        }

        public bool IsPortOnStation()
        {       
            OnRegisterTerminal(this, null);
            return true;
        }

        public event EventHandler Connected;

        protected virtual void OnConnected(object sender, EventArgs arg)
        {
            var temp = Connected;
            if (temp != null)
            {
                temp(sender, arg);
            }
        }

        public void Connect()
        {
            OnConnected(this, null);
        }

        //public void DisConnect()
        //{
        //    OnConnected(this, null);
        //}

        public override string ToString()
        {
            return Convert.ToString(Number);
        }


        public void ClearEvents()
        {
            this.CallFrom = null;
            this.RegisterTerminal = null;
            this.AcceptCall = null;
            this.EndCall = null;
        }
           
    }
}
