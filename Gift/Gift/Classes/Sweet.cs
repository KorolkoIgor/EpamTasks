using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gift
{
    public abstract class Sweet:GiftItem,IShugarCalories
    {
        public double Shugar
        {
            get;
            private set;
        }

        public double Calories
        {
            get;
           private set;
        }
     
         public Sweet(string name, double weight, double calories, double shugar)
            : base(name, weight)
        {
                 this.Calories = calories;
                 this.Shugar = shugar;
            
        }

          public abstract string GetTypeConsuption();
       
    }
}
