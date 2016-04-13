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
            if (calories > 0 && calories < 100)
            {
                this.Calories = calories;
            }
            else
            {
                if (calories > 0 && calories < 100)
                {
                    this.Calories = calories;
                }
                else
                {
                    Console.WriteLine("Element {0} not a valid value {1}! Calories greater then 0 and less 100", this.Name, calories);
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
           
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
       
        public void Duration()
        {
            Console.WriteLine("Expiration date for fruit {0} 3 months", this.Name);
        }
    }
}
