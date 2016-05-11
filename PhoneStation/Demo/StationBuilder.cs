using Billing;
using PhoneStation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class StationBuilder
    {
        
        private  Station _station;
         ICollection<Contract> _contracts; // new List<Contract>() { };
            ICollection<Terminal> _terminals;// = new List<Terminal> { };

        public StationBuilder(Station station,  ICollection<Contract> contracts, ICollection<Terminal> terminals)
        {
            _station = station;
            _contracts=contracts;
             _terminals=terminals;
        }
        
        public void Build()
        {
            AddElement();
           
        }

      


           Client Client1 = new Client(1, "Vova");
            Client Client2 = new Client(2, "Dima");
            Client Client3 = new Client(3, "Alex");

            //Terminal terminal1 = new Terminal(new PhoneNumber("777"), Station);

            ////_terminals.Add(terminal1);
            //Terminal terminal2 = new Terminal(new PhoneNumber("555"), _station);
            ////_terminals.Add(terminal2);
            //Terminal terminal3 = new Terminal(new PhoneNumber("666"), _station);
            ////_terminals.Add(terminal3);
            //Terminal terminal4 = new Terminal(new PhoneNumber("666"), _station);

        public void AddElement()
        {
            //Contract Contract1 = new Contract(1, Client1, new PlanEconom() { Name = "Econom", MinuteCost = 0.5, Discount = 10, MoreThenCalls = 5 }, new DateTime(2015, 1, 1), terminal1);
           // _contracts.Add(Contract1);
            //Contract Contract2 = new Contract(2, Client2, new PlanEconom() { Name = "Econom", MinuteCost = 0.5 }, new DateTime(2015, 6, 1), terminal2);
            //_contracts.Add(Contract2);
            ////Contract Contract3 = new Contract(3, Client2, new PlanEconom() { Name = "Econom", MinuteCost = 0.5 }, new DateTime(2015, 6, 1), terminal3);
            ////contracts.Add(Contract3);
            //Contract Contract3 = new Contract(3, Client3, new PlanStandart() { Name = "Standart", MinuteCost = 1.5 }, new DateTime(2015, 6, 10), terminal3);
            //_contracts.Add(Contract3);
        }

          
    }
}
