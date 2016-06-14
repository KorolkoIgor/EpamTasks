using SalesDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class SalesDal
    {
        private readonly  DataModelContainer1 _dbServiceEntities = new  DataModelContainer1();
        
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public ClientDal Client { get; set; }
        public GoodsDal Goods { get; set; }
        public ManagerDal Manager { get; set; }
        public double Cost { get; set; }
       
        
        public SalesDal(int id, DateTime date, ClientDal clientId, GoodsDal goodsId, ManagerDal managerId, double cost)
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
