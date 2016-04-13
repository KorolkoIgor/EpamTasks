using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gift
{
   public class Toy:GiftItem,IMadeBy
   {      
       public int MinAge
       {
           get;
          private set;
       }

      public MadeByCountry MadyByCountry
       {
           get;
           set;
       }

       public Toy(string name, double weight, int minAge, MadeByCountry madeByCountry)
           : base(name, weight)
       {
           this.MadyByCountry = madeByCountry;

           if (minAge > 0 && minAge < 16)
           {
               this.MinAge = minAge;
           }
           else
           {
               Console.WriteLine("Element {0} not a valid value {1}! MinAge greater then 0 and less 16", this.Name, minAge);
               Console.ReadLine();
               Environment.Exit(0);
           }
  
       }

       public override string ToString()
       {
           return
               string.Format("Toy: Name {0}, Weight {1}, MinAge {2},  MadyBy  {3}",
               Name,
               Weight,
               MinAge,
               MadyByCountry               
               );


       }

     
   }
}
