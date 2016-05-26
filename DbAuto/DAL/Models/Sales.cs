using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class Sales
    {

        //public Manager Manager { get; set; }
        //public Client Client { get; set; }
        //public Goods Goodds { get; set; }

        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int ManagerId { get; set; }
        public int ClientId { get; set; }
        public int GoodsId { get; set; }
        public double Cost { get; set; }
    }
}
