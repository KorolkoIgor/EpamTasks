using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift
{
    public class Candy : Sweet, IMadeBy
    {
        public CandyTypes CandyType
        {
            get;
            set;
        }
        public MadeByCountry MadyByCountry
        {
            get;
            set;
        }

        public Candy(string name, double weight, double calories, double shugar,  CandyTypes candyType, MadeByCountry madyByCountry)
            : base(name, weight, calories, shugar)
        {

            CandyType = candyType;
            MadyByCountry = madyByCountry;
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
                MadyByCountry
                );
        }
        public override void Duration()
        {
            Console.WriteLine("Expiration date for candy {0} 6 months", this.Name);
        }
    }
}