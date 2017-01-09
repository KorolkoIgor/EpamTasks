using PhoneStation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing
{
   public  interface IBillingPlan
    {
        string Name { get; set; }
        CostCallHistory GetCost(CallHistory callHistory);
        double GetBillingForPeriod(IEnumerable<CostCallHistory> allInPeriodCalls);
    }
}
