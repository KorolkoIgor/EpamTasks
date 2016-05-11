using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneStation
{
    public class Station
    {
        public ICollection<Port> Ports {get;set;}
        private IDictionary<PhoneNumber, Port> _portMapping;
        private ICollection<Terminal> _terminalCollection;
    

        public Station()
        {
            _terminalCollection = new List<Terminal>();
            this._portMapping = new Dictionary<PhoneNumber, Port>();
            Ports = new List<Port>();
            CallHistoryCreated += (sender, callHistory) =>
            {
                Console.WriteLine("Station registered call info Source {0} Target {1} Duration {2}",
                  callHistory.Source, callHistory.Target, callHistory.Duration);
            };
        }

        public event EventHandler<CallHistory> CallHistoryCreated;

        protected virtual void OnCallHistoryCreated(object sender, CallHistory callHistory)
        {
            var temp = CallHistoryCreated;

            if (temp != null)
            {
                temp(sender, callHistory);
            }
        }

        public Port AddPort(Terminal terminal)
        {
            Port creatingport = new Port(terminal);
            Ports.Add(creatingport);
            _portMapping.Add(terminal.Number, creatingport);
            _terminalCollection.Add(terminal);
            return creatingport;
        }

        //public void RemovePort(Terminal terminal)
        //{
        //    Port checkport;
        //    checkport = Ports.Find(x => x.Terminal.Number == terminal.Number);
        //    Ports.Remove(checkport);
        //    Console.WriteLine("Terminal {0} is disabled!", terminal.Number);

        //}

        protected bool GetPortByTerminal(Terminal terminal)
        {
            return _portMapping.ContainsKey(terminal.Number);
          
        }
        protected Terminal GetTerminalByPhoneNumber(PhoneNumber number)
        {
            return _terminalCollection.FirstOrDefault(x => x.Number == number);
        }

        public void TerminalRegister(object sender, EventArgs arg)
        {
            Terminal terminal = sender as Terminal;
            if (terminal != null)
            {
                  if(GetPortByTerminal(terminal) == false )
                   {
                    Console.WriteLine("Terminal number " + terminal.Number
                         + " successfully registered!");
                         AddPort(terminal);
                    }

                else
                Console.WriteLine(terminal.Number +
                     " Terminal number already exists, the terminal is not registered!");
            }
        }

        public void TerminalCall(object sender, Request request)
        {
            Terminal terminal = sender as Terminal;
            if (terminal != null)
            {
                if (GetPortByTerminal(request.Target) == true)
                {
                    Port searchport = _portMapping[request.Target.Number];

                    switch (searchport.State)
                    {
                        case PortState.Free:

                            request.Target.IncomingNumber = terminal.Number;
                            _portMapping[request.Sourse.Number].State = PortState.Busy;
                            searchport.State = PortState.Busy;
                            terminal.IncomingNumber = request.Target.Number;

                            Console.WriteLine("The terminal call!");
                            break;
                        case PortState.UnPlugged:
                            Console.WriteLine("The number is not available!");
                            break;
                        case PortState.Busy:
                            Console.WriteLine("The number {0} is busy!", request.Target);
                        terminal.callHistory = new CallHistory();
                        terminal.callHistory.StartCall = DateTime.Now;
                        terminal.callHistory.Duration = default(TimeSpan);
                        terminal.callHistory.Source = terminal;
                        terminal.callHistory.Target = request.Target;
                        request.Target.callHistory = terminal.callHistory;
                        OnCallHistoryCreated(this, terminal.callHistory);
                        terminal.callHistory = null;
                        request.Target.callHistory = null;

                            break;
                        default:
                            break;
                    }
                }
                else
                    Console.WriteLine("Number {0} does not exist!", request.Target);
               }
        }
 
        public void TerminalAnswer(object sender, EventArgs arg)
        {
            Terminal terminal = sender as Terminal;
            if (terminal != null)

            terminal.callHistory = new CallHistory();
            terminal.callHistory.StartCall = DateTime.Now;
            terminal.callHistory.Source = GetTerminalByPhoneNumber(terminal.IncomingNumber);
            terminal.callHistory.Target = GetTerminalByPhoneNumber(terminal.Number);
            GetTerminalByPhoneNumber(terminal.IncomingNumber).callHistory = GetTerminalByPhoneNumber(terminal.Number).callHistory;
            
            Console.WriteLine("Conversation with {0} with {1} started!", terminal.Number, terminal.IncomingNumber);

        }

        public void TerminalEndCall(object sender, EventArgs arg)
        {
            Terminal terminal = sender as Terminal;
            if (terminal != null)
            {
                if ( _portMapping[terminal.Number].State == PortState.Busy)
                   
                {
                    Console.WriteLine("The call is finished!");
                    _portMapping[terminal.Number].State = PortState.Free;
                    _portMapping[terminal.IncomingNumber].State = PortState.Free;
                    if (terminal.callHistory == null)
                    {

                        terminal.callHistory = new CallHistory();
                        terminal.callHistory.StartCall = DateTime.Now;
                        terminal.callHistory.Duration = default(TimeSpan);
                        terminal.callHistory.Source = GetTerminalByPhoneNumber(terminal.IncomingNumber);
                        terminal.callHistory.Target = GetTerminalByPhoneNumber(terminal.Number);
                        GetTerminalByPhoneNumber(terminal.IncomingNumber).callHistory = GetTerminalByPhoneNumber(terminal.Number).callHistory;
                        OnCallHistoryCreated(this, terminal.callHistory);
                        terminal.callHistory = null;
                        GetTerminalByPhoneNumber(terminal.IncomingNumber).callHistory = null;

                        Console.WriteLine("The call did not take place. ");

                    }
                    else
                    {
                        terminal.callHistory.Duration=(DateTime.Now - terminal.callHistory.StartCall);
                        OnCallHistoryCreated(this, terminal.callHistory);
                        terminal.callHistory = null;
                        GetTerminalByPhoneNumber(terminal.IncomingNumber).callHistory = null;
                       
                    }
                }
                else
                    Console.WriteLine("The terminal is not ringing!");
            }
        }

        public void ClearEvents()
        {
            
        }

    }
}
