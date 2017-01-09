using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift
{
    public class Candy : Sweet, ICountryCode
    {
        public string CandyType
        {
            get;
            set;
        }
        public int CountryCode
        {
            get;
            set;
        }

        public Candy(string name, double weight, double calories, double shugar,  string candyType, int countryCode)
            : base(name, weight, calories, shugar)
        {

            CandyType = candyType;
            CountryCode = countryCode;
        }

        public override string ToString()
        {
            return
                string.Format("Candy: Name {0}, Weight {1}, Calories {2}, Shugar {3}, Type {4}, MadyBy {5}",
                Name,
                Weight,
                Calories,
                Shugar,
                CandyType,
                CountryCode
                );
        }
        public override string GetTypeConsuption()
        {
            if (this.Shugar>=15 && this.Calories>=30)
            return  "Cut";
            else return "Normal ";
        }
    }
}