using Billing;
using PhoneStation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
           
            ICollection<Contract> contracts = new List<Contract>() { };
            ICollection<Port> ports = new List<Port>() { new Port(), new Port(), new Port(), new Port(), new Port() };
            Station My = new Station(ports);

                              
            BillingSystem bs = new BillingSystem(contracts);
            My.CallHistoryCreated += bs.AddCallHistory;


            Client Client1 = new Client(1, "Vova");
            Client Client2 = new Client(2, "Dima");
            Client Client3 = new Client(3, "Alex");

            Terminal terminal1 = new Terminal(new PhoneNumber("777"));
            My.AddTerminal(terminal1);
          
            Terminal terminal2 = new Terminal(new PhoneNumber("555"));
            My.AddTerminal(terminal2);
            Terminal terminal3 = new Terminal(new PhoneNumber("666"));
            My.AddTerminal(terminal3);
            Terminal terminal4 = new Terminal(new PhoneNumber("666"));
            My.AddTerminal(terminal4);
            Terminal terminal5 = new Terminal(new PhoneNumber("444"));
            My.AddTerminal(terminal5);
            Terminal terminal6 = new Terminal(new PhoneNumber("333"));
            My.AddTerminal(terminal6);

            Contract Contract1 = new Contract(1, Client1, new PlanEconom() { Name = "Econom", minuteCost = 0.5, discount = 10, moreThenCalls = 5 }, new DateTime(2015, 1, 1), terminal1);
            contracts.Add(Contract1);
            Contract Contract2 = new Contract(2, Client2, new PlanEconom() { Name = "Econom", minuteCost = 0.5, discount = 10, moreThenCalls = 5 }, new DateTime(2015, 6, 1), terminal2);
            contracts.Add(Contract2);
            Contract Contract3 = new Contract(3, Client3, new PlanStandart() { Name = "Standart", minuteCost = 1.5 }, new DateTime(2015, 6, 10), terminal3);
            contracts.Add(Contract3);
            Contract Contract5 = new Contract(5, Client2, new PlanEconom() { Name = "Econom", minuteCost = 0.5, discount = 10, moreThenCalls = 5 }, new DateTime(2015, 6, 1), terminal5);
            contracts.Add(Contract5);
            Contract Contract6 = new Contract(6, Client1, new PlanStandart() { Name = "Standart", minuteCost = 1.5 }, new DateTime(2015, 8, 1), terminal6);
            contracts.Add(Contract6);

            
           My.ActivateTerminal(terminal1);
           My.ActivateTerminal(terminal2);
           My.ActivateTerminal(terminal3);
           My.ActivateTerminal(terminal5);
           My.ActivateTerminal(terminal6);


           terminal6.Call(terminal1);
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
           Thread.Sleep(6000);
           terminal1.Drop();

           terminal5.Call(terminal3);
           terminal3.Answer();
           Thread.Sleep(3000);
           terminal5.Drop();

           terminal1.Call(terminal2);
           terminal2.Answer();
           Thread.Sleep(4000);
           terminal1.Drop();

           My.DisActivateTerminal(terminal1);

           terminal6.Call(terminal1);
           Thread.Sleep(3000);
           terminal1.Answer();
           Thread.Sleep(3000);
           terminal1.Drop();


           My.ActivateTerminal(terminal1);

           terminal1.Call(terminal5);
           terminal5.Answer();
           Thread.Sleep(3000);
           terminal1.Drop();

           //My.RemoveTerminal(terminal3);
           //contracts.Remove(bs.GetContractForTerminal(terminal3));

           My.ClearEvents();


            Console.WriteLine("------------------------------------------------");

            foreach (var c in bs.GetCallListBy(terminal1))
            {

                Console.WriteLine("By Terminal--Sourse {0}:  Cost {1}; Duration {2};", c.Source.Number, c.Cost, c.Duration);
                Console.WriteLine(" Target {0}; Started {1}", c.Target.Number, c.StartCall);
            }

            Console.WriteLine("------------------------------------------------");

            foreach (var c in bs.GetCallListBy(Client2))
            {
                Console.WriteLine("By Client {3}--Sourse {0}:  Cost {1}; Duration {2};", c.Source.Number, c.Cost, c.Duration, Client3.name);
                Console.WriteLine(" Target {0}; Started {1}", c.Target.Number, c.StartCall);
            }

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Total amount for the month {0} : {1} EUR;", terminal1.Number, bs.GetBillingForPeriodBy(terminal1, new DateTime(2016, 5, 1), new DateTime(2016, 5, 31)));
            Console.WriteLine("------------------------------------------------");

            Contract1.BillingPlanChange(new PlanStandart() { Name = "Standart", minuteCost = 1.5 }, DateTime.Now);


            Console.ReadKey();
        
     
        }
    }
}
