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
            if (calories > 0 && calories < 100)
            {
                 this.Calories = calories;
            }
            else
            {
                Console.WriteLine("Element {0} not a valid value {1}! Calories greater then 0 and less 100",this.Name, calories);
                Console.ReadLine();
                Environment.Exit(0);
            }
            
        if (shugar > 0 && shugar < 100)
            {
                  this.Shugar = shugar;
            }
            else
           {     
            Console.WriteLine("Element {0} not a valid value {1}! Chugar greater then 0 and less 100",this.Name, shugar);
            Console.ReadLine();
            Environment.Exit(0);
            }
        }

          public abstract void Duration();
       
    }
}
