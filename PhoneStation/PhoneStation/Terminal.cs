using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneStation
{
    public class Terminal:ITerminal
    {
        public PhoneNumber Number { get; set; }
        public Contract Contract { get; set; }
        public Port Link { get; set; }




        public event EventHandler<Request> CallFrom;

        public event EventHandler<RegisterTerminal> RegisterTerminal;

        public event EventHandler AcceptCall;

        public event EventHandler EndCall;

        public void Call(Terminal target)
        {
            throw new NotImplementedException();
        }

        public void Answer()
        {
            throw new NotImplementedException();
        }

        public void Drop()
        {
            throw new NotImplementedException();
        }

        public void OnPort()
        {
            throw new NotImplementedException();
        }

        public bool IsPortOnStation()
        {
            throw new NotImplementedException();
        }

        public void ClearEvents()
        {
            throw new NotImplementedException();
        }
    }
}
