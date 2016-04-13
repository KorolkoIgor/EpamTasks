using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift
{
    public class Gift
    {
        private IList<IGiftItem> _items = new List<IGiftItem>();


        public IEnumerable<IGiftItem> Items
        {
            get { return _items.ToList(); }
        }

        public void Clear()
        {
            _items.Clear();
        }

        public void AddRange(IEnumerable<IGiftItem> newItems)
        {
            foreach (var giftItem in newItems)
            {
                _items.Add(giftItem);
            }
        }

        public void Add(IGiftItem sweet)
        {
            if (sweet != null)
            {
                this._items.Add(sweet);
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        public void Remove(IGiftItem sweet)
        {
            this._items.Remove(sweet);
        }

        public void SortByCalories()
        {
            var sweets = Items.Where(x => x is ICalories).ToList();
            var rest = Items.Except(sweets).ToList();
            var newItems = sweets.Cast<ICalories>().OrderBy(x => x.Calories).Concat(rest);
            this.Clear();
            this.AddRange(newItems);
            foreach (var s in Items)
            {
                Console.WriteLine(s.Name);
            }

        }

        public void FirstOrDefault(double minShugar, double maxShugar)
        {
            var shugar = Items.Where(x => x is IShugarCalories).Cast<IShugarCalories>().FirstOrDefault(x =>
                x.Shugar <= maxShugar && x.Shugar >= minShugar);
            if (shugar != null)
            {
                Console.WriteLine("{0} - {1}",shugar.Name, shugar.Shugar);
            }
            else
                Console.WriteLine("No item in gift");

        }

        public void GetMadeByCountry(MadeByCountry madeByCountry)
        {
            var sweets = Items.Where(x => x is IMadeBy).ToList();
            var newItems = sweets.Cast<IMadeBy>().Where(x => x.MadyByCountry == madeByCountry).ToList();

            if (newItems != null)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Mady by {0} this product: ", madeByCountry);

                foreach (var s in newItems)
                {
                    Console.WriteLine(s.Name);
                }
            }
        }
    }
}

    
                  
        


    

