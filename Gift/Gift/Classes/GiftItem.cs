using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift
{
   public abstract class GiftItem:IGiftItem
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
           
                this.Name = name;
               this.Weight = weight;
         }
    }
}
