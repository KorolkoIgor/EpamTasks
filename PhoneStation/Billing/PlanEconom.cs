using PhoneStation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing
{
    public class PlanEconom:IBillingPlan
    {
        public string Name { get; set; }
        public double minuteCost;
        public double discount;
        public int moreThenCalls;

        public CostCallHistory GetCost(CallHistory callHistory)
        {
            return new CostCallHistory()
            {
                Cost = callHistory.Duration.TotalMinutes * minuteCost,
                Target = callHistory.Target,
                Source = callHistory.Source,
                Duration = callHistory.Duration,
                StartCall = callHistory.StartCall
            };
        }
        public double GetBillingForPeriod(IEnumerable<CostCallHistory> allInPeriodCalls)
        {
            double d = 0.0;
            foreach (CostCallHistory c in allInPeriodCalls)
            {
                d += c.Cost;
            }
            d -= countDiscount(allInPeriodCalls.Count());
            return d;
        }

       

        private double countDiscount(int paymentInPeriod)
        {
            if (paymentInPeriod > moreThenCalls)
            {
                return discount;
            }
            return 0;

        }
    }
}
