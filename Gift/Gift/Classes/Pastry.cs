using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift
{
    public class Pastry:Sweet
    {
         public string PastryTypes { get; set; }

        public Pastry(string name, double weight, double calories, double shugar, string pastryTypes)
            : base(name, weight, calories, shugar )
        {
          
            PastryTypes =   pastryTypes;
        }
         public override string ToString()
        {
            return
                string.Format("Pastry: Name {0}, Weight {1}, Calories {2}, Shugar {3}, Type {4}",
                Name,
                Weight,
                Calories,
                Shugar,
                PastryTypes
                );
        }
        public override string GetTypeConsuption()
        {
            if (this.Shugar >= 25 && this.Calories >= 30)
                return "Very limiteed ";
            else return "Cut ";
        }
    }
}
