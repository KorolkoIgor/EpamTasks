using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift
{
    public class OtherSweet:Sweet
    {
         public OtherSweetTypes OtherSweetTypes { get; set; }

        public OtherSweet(string name, double weight, double calories, double shugar, OtherSweetTypes otherSweetTypes)
            : base(name, weight, calories, shugar )
        {
          
            OtherSweetTypes =   otherSweetTypes;
        }
         public override string ToString()
        {
            return
                string.Format("OtherSweet: Name {0}, Weight {1}, Calories {2}, Shugar {3}, Type {4}",
                Name,
                Weight,
                Calories,
                Shugar,
                OtherSweetTypes
                );
        }
        public override void Duration()
        {
            Console.WriteLine("Expiration date for candy {0} 4 months", this.Name);
        }
    }
}
