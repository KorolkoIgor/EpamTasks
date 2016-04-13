using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift
{
    class Program
    {
        static void Main(string[] args)
        {
           
                var gift = new Gift();

                gift.Add(new Toy("Puzzle", 334, 7, MadeByCountry.Russia));
                gift.Add(new Toy("PaintChildren", 122, 4, MadeByCountry.Belarus));
                gift.Add(new Toy("TableGame", 564, 9, MadeByCountry.China));

                gift.Add(new OtherSweet("Nuts", 164, 23, 23, OtherSweetTypes.Cookies));
                gift.Add(new OtherSweet("Smile", 264, 43, 27, OtherSweetTypes.Zephyr));
                gift.Add(new OtherSweet("Flying", 134, 18, 17, OtherSweetTypes.Wafers));
                gift.Add(new OtherSweet("Berry", 356, 65, 46, OtherSweetTypes.FruitJelly));

                gift.Add(new Fruit("Mandarin", 520, 34));
                gift.Add(new Fruit("Orange", 680, 24));

                gift.Add(new Candy("Rabbit", 80, 45, 27, CandyTypes.Truffle, MadeByCountry.Russia));
                gift.Add(new Candy("Bird", 120, 24, 41, CandyTypes.Souffle, MadeByCountry.Belarus));
                gift.Add(new Candy("Night", 194, 19, 17, CandyTypes.Fondant, MadeByCountry.China));
                gift.Add(new Candy("Apple", 87, 33, 41, CandyTypes.Caramel, MadeByCountry.Belarus));

             


            Console.WriteLine("\n The gift is:");
          
            Console.WriteLine();

            foreach (var s in gift.Items)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Total Weight:{0}", gift.Items.Sum(x => x.Weight));

            Console.WriteLine("-----------------------------------------------");
           
           Console.WriteLine("Sortable by caloris:");
           Console.WriteLine("-----------------------------------------------");
            gift.SortByCalories();
         

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("The shugar is greater then 10 and less 35:");
           
            gift.FirstOrDefault(10,35);
             
             gift.GetMadeByCountry(MadeByCountry.Belarus);
             
            Candy candy = new Candy("Plum", 80, 45, 27, CandyTypes.Truffle, MadeByCountry.Russia);
            OtherSweet othersweet = new OtherSweet("Moment", 164, 23, 23, OtherSweetTypes.Cookies);
            Fruit fruit = new Fruit("Kiwi", 520, 34);
                                  
            Console.WriteLine("-----------------------------------------------");
            candy.Duration();
            othersweet.Duration();
            fruit.Duration();

           
            Console.ReadLine();

        }
       
    }
}
