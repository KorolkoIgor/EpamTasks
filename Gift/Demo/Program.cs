using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gift;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var gift = new Gift.Gift(new List<IGiftItem>());
            GiftBuilder builder = new GiftBuilder(gift);
            builder.Build();

            Console.WriteLine("\n The gift is:");
            Console.WriteLine();

            foreach (var s in gift.Items)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Total Weight:{0}", gift.GetTotalSum());

            Console.WriteLine("-----------------------------------------------");

            Console.WriteLine("Sort by calories:");
            Console.WriteLine("-----------------------------------------------");
            gift.SortByCalories();
            foreach (var s in gift.Items)
            {
                Console.WriteLine(s.Name);
            }

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("The shugar is greater then 10 and less 35:");
            if (gift.GetByShugar(10, 35) != null)
            {
                foreach (var s in gift.GetByShugar(10, 35))
                {
                    Console.WriteLine("{0} - {1}", s.Name, s.Shugar);
                }
            }
            else
                Console.WriteLine("No item in gift whith this shugar");

            Console.WriteLine("-----------------------------------------------");
            if (gift.GetByCodeCountry(481) != null)
            {
                Console.WriteLine("Mady by Belarus this product: ");
                foreach (var c in gift.GetByCodeCountry(481))
                    Console.WriteLine(c.Name);
            }
            else
                Console.WriteLine("No item in gift by Belarus");

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Type of Consuption");
            foreach (var s in gift.GetByCalories())
            {
                
                Console.WriteLine("{0}, {1}",s.Name, s.GetTypeConsuption());
            }

            Console.ReadLine();
        }
    }
}
    

