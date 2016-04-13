using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift
{
   public class GiftItem:IGiftItem
    {   
        public string Name
        {
            get;
           private set;
        }

        public double Weight
        {
            get;
            private set;
        }

        public GiftItem(string name, double weight)
        {
            if (name != "")
            {
                this.Name = name;
            }
            else
            {
                Console.WriteLine("Element not a valid name! Please Chek.");
                Console.ReadLine();
                Environment.Exit(0);
            }

           if (weight > 0 && weight < 1000)
           {
               this.Weight = weight;
           }
           else
           {
               Console.WriteLine("Element {0} not a valid value {1}! Wieght greater then 0 and less 1000", this.Name, weight);
               Console.ReadLine();
               Environment.Exit(0);
           }
        }
    }
}
