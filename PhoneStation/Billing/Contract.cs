using PhoneStation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Billing
{
   public  class Contract
    {
        private int contractID;
        public Client client;
        public IBillingPlan plan;
        private DateTime lastBillingPlanChange;
        public Terminal terminal;

        public Contract(int contractid, Client client, IBillingPlan billingplan, DateTime registrationdate, Terminal terminal)
        {
            contractID = contractid;
            this.client = client;
            plan = billingplan;
            lastBillingPlanChange = registrationdate;
            this.terminal = terminal;

        }

        public void BillingPlanChange(IBillingPlan new_billingplan, DateTime new_registrationdate)
        {
            if (contractID != 0)             // && (Client != null))
            {
                if (lastBillingPlanChange != null)
                {
                    if ((new_registrationdate - lastBillingPlanChange) >= new TimeSpan(30, 0, 0, 0))
                    {
                        plan = new_billingplan;
                        lastBillingPlanChange = new_registrationdate;
                        Console.WriteLine("Client {0} changed tariff plan  successfully!", this.client.name);
                    }
                    else
                        Console.WriteLine("Unable to change billing plan. 30 days must passafter last change");
                }
            }
            else
                Console.WriteLine("Register your contract first!");
        }
    }
}
