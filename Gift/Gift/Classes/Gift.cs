using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift
{
    public class Gift
    {
        private ICollection<IGiftItem> _items;

        public Gift(ICollection<IGiftItem> source)
        {
            this._items = source;
        }

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

        public double GetTotalSum()
        {
            return this.Items.Sum(x => x.Weight);
        }

        public void SortByCalories()
        {
            var sweets = Items.Where(x => x is ICalories).ToList();
            var rest = Items.Except(sweets).ToList();
            var newItems = sweets.Cast<ICalories>().OrderBy(x => x.Calories).Concat(rest);
            this.Clear();
            this.AddRange(newItems);
        }

        public IEnumerable<IShugarCalories> GetByShugar(double minShugar, double maxShugar)
        {
            var shugar = Items.Where(x => x is IShugarCalories).Cast<IShugarCalories>().Where(x =>
                 x.Shugar <= maxShugar && x.Shugar >= minShugar);
            return shugar;
        }

        public IEnumerable<ICountryCode> GetByCodeCountry(int codeCountry)
        {
            var sweets = Items.Where(x => x is ICountryCode).Cast<ICountryCode>().Where(x => x.CountryCode == codeCountry).ToList();
             return sweets;

        }

        public IEnumerable<ICalories> GetByCalories()
        {  
            var sweets = Items.Where(x => x is ICalories).Cast<ICalories>().ToList();
            return sweets;

        }
    }
  }
    


    
                  
        


    

