using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStation
{
    public interface ITerminal
    {
        //assignment of a phone number to the terminal
        PhoneNumber Number { get; }

        //Event: to make an outcoming call from the terminal to station
        event EventHandler<Request> OutcomingCall;



        //Event: to make an incoming call from the station to terminal 
        event EventHandler<OutCallRequest> IncomingRequest;

        //Event: terminal send respond to the station  
        event EventHandler<Respond> IncomingRespond;

        //Event: terminal set the connection  
        event EventHandler OnlineMode;

        //Event: terminal cut of the connection  
        event EventHandler OfflineMode;

        //Event: user plug the device  
        event EventHandler Connected;

        //Event: user unplug device  
        event EventHandler DisConnected;



        void IncomingRequestFrom(PhoneNumber source);
        void Call(PhoneNumber target);
        void Drop();
        void Answer();
        void Connect();
        void DisConnect();

        // registration port
        void RegisterEventHandlersForPort(Port port);

        void ClearEvents();
       
    }
}
