using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneStation
{
    public class Station
    {
       
        public IDictionary<PhoneNumber, Port> _portMapping;
        private ICollection<Terminal> _terminalCollection;
        private bool IsCall { get; set; }
        private Terminal dropTerminal;

        public Station()
        {
            _terminalCollection = new List<Terminal>();
            this._portMapping = new Dictionary<PhoneNumber, Port>();
         
            CallHistoryCreated += (sender, callHistory) =>
            {
                Console.WriteLine("Station registered call info Source {0} Target {1} Duration {2}",
                  callHistory.Source, callHistory.Target, callHistory.Duration);
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
            Port creatingport = new Port();
       
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
                                IsCall = true;
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
                                terminal.callHistory = new CallHistory();
                                terminal.callHistory.StartCall = DateTime.Now;
                                terminal.callHistory.Duration = default(TimeSpan);
                                terminal.callHistory.Source = terminal;
                                terminal.callHistory.Target = request.Target;
                             
                                OnCallHistoryCreated(this, terminal.callHistory);
                                terminal.callHistory = null;
                                

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
            if (terminal != null && IsCall)
            {
                terminal.callHistory = new CallHistory();
                terminal.callHistory.StartCall = DateTime.Now;
                terminal.callHistory.Source = GetTerminalByPhoneNumber(terminal.IncomingNumber);
                terminal.callHistory.Target = GetTerminalByPhoneNumber(terminal.Number);
              GetTerminalByPhoneNumber(terminal.IncomingNumber).callHistory = GetTerminalByPhoneNumber(terminal.Number).callHistory;

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
                    if (terminal.callHistory == null)
                    {

                        terminal.callHistory = new CallHistory();
                        terminal.callHistory.StartCall = DateTime.Now;
                        terminal.callHistory.Duration = default(TimeSpan);
                        if (dropTerminal == terminal)
                        {
                            terminal.callHistory.Source = GetTerminalByPhoneNumber(terminal.Number);
                            terminal.callHistory.Target = GetTerminalByPhoneNumber(terminal.IncomingNumber);
                        }
                        else
                        {
                            terminal.callHistory.Source = GetTerminalByPhoneNumber(terminal.IncomingNumber);
                            terminal.callHistory.Target = GetTerminalByPhoneNumber(terminal.Number);
                        }
                       
                        OnCallHistoryCreated(this, terminal.callHistory);
                        terminal.callHistory = null;
                       

                        Console.WriteLine("The call did not take place. ");

                    }
                    else
                    {
                        terminal.callHistory.Duration=(DateTime.Now - terminal.callHistory.StartCall);
                        OnCallHistoryCreated(this, terminal.callHistory);
                        terminal.callHistory = null;
                       
                       
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
