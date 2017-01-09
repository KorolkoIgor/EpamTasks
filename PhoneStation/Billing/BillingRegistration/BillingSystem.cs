using PhoneStation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billing
{
    public class BillingSystem
    {
        ICollection<CostCallHistory> callCollection;
        ICollection<Contract> contracts;
    

        public BillingSystem(ICollection<Contract> contracts)
        {
            if (contracts != null)
            {
                this.contracts = contracts;
            }
            else
            {
                this.contracts = new List<Contract>();
            }
            callCollection = new List<CostCallHistory>();
        }
        public void AddCallHistory(object sender, CallHistory e)
        {
            Console.WriteLine("! Billing system received info: {0}; ---  {1}; ---  {2};", e.Source.Number, e.Target.Number, e.Duration);
            callCollection.Add(GetContractForTerminal(e.Source).plan.GetCost(e));
        }

        public Contract GetContractForTerminal(Terminal terminal)
        {
            var tt = contracts.FirstOrDefault(x => x.terminal.Number == terminal.Number);
           return tt; 
        }

        public ICollection<CostCallHistory> GetCallListBy(Terminal terminal)
        {
            Console.WriteLine("All calls terminal Number {0}", terminal.Number);
            return (from c in callCollection
                    where (c.Source.Number == terminal.Number)
                    select c).ToList();
        }
        public ICollection<CostCallHistory> GetCallListBy(Terminal terminal, DateTime fromDate)
        {
            var a = (from c in callCollection
                     where (c.Source.Number == terminal.Number  && c.StartCall >= fromDate)
                     select c);
            return a.ToList();
        }

        public ICollection<CostCallHistory> GetCallListBy(Client client)
        {
            List<CostCallHistory> calls = new List<CostCallHistory>();
            foreach (var contract in contracts)
            {
                if (contract.client.clientID == client.clientID)
                {
                    calls.AddRange((from c in callCollection
                                    where (c.Source.Number == contract.terminal.Number)
                                    select c));
                }
            }
            return calls;

        }
        public ICollection<CostCallHistory> GetCallListBy(Client client, DateTime fromDate)
        {
            List<CostCallHistory> calls = new List<CostCallHistory>();
            foreach (var contract in contracts)
            {
                if (contract.client.clientID == client.clientID)
                {
                    calls.AddRange((from c in callCollection
                                    where (c.Source.Number == contract.terminal.Number  && c.StartCall >= fromDate)
                                    select c));
                }
            }
            return calls;

        }

        public double GetBillingForPeriodBy(Client client, DateTime fromDate, DateTime toDate)
        {
            double result = 0.0;
            foreach (var contract in contracts)
            {
                if (contract.client.clientID == client.clientID)
                {
                    result += contract.plan.GetBillingForPeriod((from c in callCollection
                                                                 where (c.Source.Number == contract.terminal.Number && c.StartCall >= fromDate && c.StartCall < toDate)
                                                                          select c));
                }
            }
            return result;
        }

        public double GetBillingForPeriodBy(Terminal terminal, DateTime fromDate, DateTime toDate)
        {

            return GetContractForTerminal(terminal).plan.GetBillingForPeriod((
                from c in callCollection
                where (c.Source.Number == terminal.Number && c.StartCall >= fromDate && c.StartCall < toDate)
                select c));
        }
    }
}
