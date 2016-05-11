using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneStation
{
    class Program
    {
        static void Main(string[] args)
        {
            Station Mts = new Station();

            Terminal terminal1 = new Terminal(new PhoneNumber("777"),  Mts);
            
            Terminal terminal2 = new Terminal(new PhoneNumber("555"), Mts);
            
            Terminal terminal3 = new Terminal(new PhoneNumber("666"), Mts);
            
            Terminal terminal4 = new Terminal(new PhoneNumber("666"),  Mts);


            terminal1.Connect();
            terminal2.Connect();
            terminal3.Connect();
            terminal4.Connect();
            //terminal2.OnPort();
            //terminal3.OnPort();
            //terminal4.OnPort();

            terminal3.Call(terminal1);
            Thread.Sleep(3000);
            terminal1.Answer();
            Thread.Sleep(3000);
            terminal1.Drop();

            terminal3.Call(terminal1);
            Thread.Sleep(3000);
            terminal3.Drop();

            terminal2.Call(terminal3);
            terminal1.Call(terminal3);
            Thread.Sleep(5000);
            terminal3.Answer();
            Thread.Sleep(3000);
            terminal3.Drop();

            terminal1.Call(terminal3);
            terminal3.Answer();
            Thread.Sleep(3000);
            terminal1.Drop();

            terminal1.Call(terminal2);
            Thread.Sleep(2000);
            terminal2.Drop();

            //terminal3.OffPort(My);

            Console.ReadLine();
        }
    }
}
