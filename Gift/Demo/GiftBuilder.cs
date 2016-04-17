using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gift;

namespace Demo
{
    public class GiftBuilder
    {
        private Gift.Gift _gift;

        public GiftBuilder(Gift.Gift gift)
        {
            _gift = gift;
        }

        public void Build()
        {
            AddElement();
           
        }

        protected void AddElement()
        {
            _gift.Add(new Toy("Puzzle", 334, 7, 460));
            _gift.Add(new Toy("PaintChildren", 122, 4, 481));
            _gift.Add(new Toy("TableGame", 564, 9, 690));

            _gift.Add(new Pastry("Nuts", 164, 23, 23, "Cookies"));
            _gift.Add(new Pastry("Smile", 264, 43, 27, "Zephyr"));
            _gift.Add(new Pastry("Flying", 134, 18, 17, "Wafers"));
            _gift.Add(new Pastry("Berry", 356, 65, 46, "FruitJelly"));

            _gift.Add(new Fruit("Mandarin", 520, 34));
            _gift.Add(new Fruit("Orange", 680, 24));

            _gift.Add(new Candy("Rabbit", 80, 45, 27, "Truffle", 460));
            _gift.Add(new Candy("Bird", 120, 24, 41, "Souffle", 481));
            _gift.Add(new Candy("Night", 194, 19, 17, "Fondant", 690));
            _gift.Add(new Candy("Apple", 87, 33, 41, "Caramel", 481));

        }

     
    }
}
 