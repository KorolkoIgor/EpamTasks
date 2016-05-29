using SalesDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class SalesDTO
    {
      
        public System.DateTime Date { get; set; }
        public int ClientId { get; set; }
        public int GoodsId { get; set; }
        public int ManagerId { get; set; }
        public double Cost { get; set; }


        public SalesDTO(DateTime date, int clientId, int goodsId, int managerId, double cost)
        {
            Date = date;
            ClientId = clientId;
            GoodsId = goodsId;
            ManagerId = managerId;
            Cost = cost;
        }

    }
    
       
}
