using SalesDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class SalesDTO
    {
        private readonly  DataModelContainer1 _dbServiceEntities = new  DataModelContainer1();
        
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public ClientDTO Client { get; set; }
        public GoodsDTO Goods { get; set; }
        public ManagerDTO Manager { get; set; }
        public double Cost { get; set; }
       
        
        public SalesDTO(int id, DateTime date, ClientDTO clientId, GoodsDTO goodsId, ManagerDTO managerId, double cost)
        {
            Id = id;
            Date = date;
            Client = clientId;
            Goods = goodsId;
            Manager = managerId;
            Cost = cost;
        }

     }
}
