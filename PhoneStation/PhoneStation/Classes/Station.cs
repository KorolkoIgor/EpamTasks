using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneStation
{
    public class Station
    {
        private IDictionary<PhoneNumber, Port> _portMapping;
        private ICollection<Terminal> _terminalCollection;
        private ICollection<Port> _portCollection;
        private Terminal dropTerminal;
        private CallHistory callHistory;
  

        public Station(ICollection<Port> portCollection)
        {
            _portCollection = portCollection;
            _terminalCollection = new List<Terminal>();
            this._portMapping = new Dictionary<PhoneNumber, Port>();
         
            CallHistoryCreated += (sender, callHistory) =>
            {
                Console.WriteLine("Station registered call info Source {0} Target {1} Duration {2}",
                  callHistory.Source.Number, callHistory.Target.Number, callHistory.Duration);
            };
        }

        public void RegisterEventHandlersForTerminal(Terminal terminal)
        {
            terminal.CallFrom += TerminalCall;
            terminal.AcceptCall += TerminalAnswer;
            terminal.EndCall += TerminalEndCall;
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

        public void  AddTerminal(Terminal terminal)
        {
            var creatingport = _portCollection.Except(_portMapping.Values).FirstOrDefault();

            if (creatingport != null)
            {
                if (GetPortByTerminal(terminal) == false)
                {
                    _portMapping.Add(terminal.Number, creatingport);
                    _terminalCollection.Add(terminal);
                    Console.WriteLine("Terminal number " + terminal.Number
                        + " successfully registered!");
                    Console.WriteLine("Port terminal number {0} detected the State is changed to UnPlugged", terminal.Number);
                }
                else
                {
                    Console.WriteLine(terminal.Number +
                         " Terminal number already exists, the terminal is not registered!");
                }
            }
            else
            {
                Console.WriteLine("No port for registration new terminal");
                Console.ReadLine();
            }      
         }

        public void ActivateTerminal(Terminal terminal)
        {
            RegisterEventHandlersForTerminal(terminal);
            if (GetPortByTerminal(terminal) == true)
            {
                Console.WriteLine("Terminal {0} plug to port", terminal.Number);
                _portMapping[terminal.Number].RegisterEventHandlersForPort(terminal);
                _portMapping[terminal.Number].State = PortState.Free;
            }
        }
     

        public void DisActivateTerminal(Terminal terminal)
        {
              Console.WriteLine("Terminal {0} unplug to port", terminal.Number);
              _portMapping[terminal.Number].State = PortState.UnPlugged;
               terminal.ClearEvents();
              _portMapping[terminal.Number].ClearEvents();
        }



        public void RemoveTerminal(Terminal terminal)
        {
            terminal.ClearEvents();
            _portMapping[terminal.Number].ClearEvents();
            _portMapping.Remove(terminal.Number);
            _terminalCollection.Remove(terminal);
            Console.WriteLine("Terminal {0} is removed to station!", terminal.Number);
         }

        private bool GetPortByTerminal(Terminal terminal)
        {
            return _portMapping.ContainsKey(terminal.Number);
        }
        
        private Terminal GetTerminalByPhoneNumber(PhoneNumber number)
        {
            return _terminalCollection.FirstOrDefault(x => x.Number == number);
        }

        public void TerminalCall(object sender, Request request)
        {
            Terminal terminal = sender as Terminal;
            if (terminal != null)
            {
                 Port sourseport = _portMapping[terminal.Number];
               
                if (sourseport.State == PortState.Free)
                {
                    if (GetPortByTerminal(request.Target) == true)
                    {
                        Port searchport = _portMapping[request.Target.Number];

                        switch (searchport.State)
                        {
                            case PortState.Free:
                             
                                dropTerminal = terminal;
                                request.Target.IncomingNumber = terminal.Number;
                                _portMapping[terminal.Number].State = PortState.Busy;
                                searchport.State = PortState.Busy;
                                terminal.IncomingNumber = request.Target.Number;

                                Console.WriteLine("The terminal call!");
                                break;

                            case PortState.UnPlugged:
                                Console.WriteLine("The number is not available!");
                                break;
                            case PortState.Busy:
                                Console.WriteLine("The number {0} is busy!", request.Target);
                                callHistory = new CallHistory();
                               callHistory.StartCall = DateTime.Now;
                               callHistory.Duration = default(TimeSpan);
                               callHistory.Source = terminal;
                               callHistory.Target = request.Target;
                             
                                OnCallHistoryCreated(this, callHistory);
                               callHistory = null;
                               break;
                            
                            default:
                                break;
                        }
                    }
                    else
                        Console.WriteLine("Number {0} does not exist!", request.Target);
                }
                else
                    if (sourseport.State == PortState.UnPlugged)
                        Console.WriteLine("Terminal {0} unplugged to port", terminal.Number);
                    else
                        Console.WriteLine("Port terminal {0} is busy", terminal.Number);
            }
        }
 
        public void TerminalAnswer(object sender, EventArgs arg)
        { 
            Terminal terminal = sender as Terminal;
            if (terminal != null )
            {
                callHistory = new CallHistory();
                callHistory.StartCall = DateTime.Now;
                callHistory.Source = GetTerminalByPhoneNumber(terminal.IncomingNumber);
                callHistory.Target = terminal;
             
                Console.WriteLine("Conversation with {0} with {1} started!", terminal.Number, terminal.IncomingNumber);
            }
          
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
                    if (callHistory == null)
                    {
                        Console.WriteLine("The call did not take place. ");

                        callHistory = new CallHistory();
                        callHistory.StartCall = DateTime.Now;
                        callHistory.Duration = default(TimeSpan);
                        if (dropTerminal == terminal)
                        {
                          callHistory.Source = terminal;
                          callHistory.Target = GetTerminalByPhoneNumber(terminal.IncomingNumber);
                        }
                        else
                        {
                          callHistory.Source = GetTerminalByPhoneNumber(terminal.IncomingNumber);
                          callHistory.Target = terminal;
                        }
                       
                        OnCallHistoryCreated(this, callHistory);
                        callHistory = null;
               
                    }
                    else
                    {
                        callHistory.Duration=(DateTime.Now - callHistory.StartCall);
                        OnCallHistoryCreated(this, callHistory);
                        callHistory = null;
                    }
                }
                else
                    Console.WriteLine("The terminal is not ringing!");
            }
        }

        public void ClearEvents()
        {
             if (_terminalCollection.Count == 0)
            {
                this.CallHistoryCreated = null; 
                Console.WriteLine("A station does not have a connected terminal.");
                Console.WriteLine("The event handler is disabled!");
            }
            else
            {
                Console.WriteLine("Connected terminals. You cannot disable station!");
            }
        
        }

    }
}
