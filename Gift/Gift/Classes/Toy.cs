using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gift
{
   public class Toy:GiftItem, ICountryCode
   {      
       public int MinAge
       {
           get;
          private set;
       }

       public int CountryCode
       {
           get;
           set;
       }

      public Toy(string name, double weight, int minAge, int countryCode)
           : base(name, weight)
       {
           this.CountryCode = countryCode;
           this.MinAge = minAge;
        }

       public override string ToString()
       {
           return
               string.Format("Toy: Name {0}, Weight {1}, MinAge {2},  MadyBy  {3}",
               Name,
               Weight,
               MinAge,
               CountryCode               
               );


       }

     
   }
}
