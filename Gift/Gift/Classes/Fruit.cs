using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift
{
    public class Fruit:GiftItem, ICalories
    {
      
        public double Calories
        {
            get;
           private set;
        }
     
        public Fruit(string name, double weight, double calories):base(name, weight)
        {
           
                this.Calories = calories;
        }

        public override string ToString()
        {
            return
                string.Format("Fruit: Name {0}, Weight {1}, Caloris {2}",
                Name,
                Weight,
                Calories
                ); 
        }
       
        public string GetTypeConsuption()
        {
            return "Unlimited";
        }
    }
}
