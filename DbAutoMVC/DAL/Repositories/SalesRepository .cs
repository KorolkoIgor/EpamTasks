﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DAL.Models;
using SalesDataModel;

namespace DAL.Repositories
{
    public class SalesRepository :  IRepository<SalesDTO>
    {
        public DataModelContainer1 context = new DataModelContainer1();

        public readonly ICollection<SalesDTO> _saleslist = new List<SalesDTO>();

       public Sales ToEntity(SalesDTO sourse)
        {
            var sales = new Sales()
            {Id=sourse.Id,
                Date = sourse.Date,
                ClientId = sourse.Client.Id,
                GoodsId = sourse.Goods.Id,
                ManagerId = sourse.Manager.Id,
                Cost = sourse.Cost
            };
            return sales;
        }

        private SalesDTO ToObject(SalesDataModel.Sales source)
       {
           return new Models.SalesDTO(source.Id,
            source.Date,
             new Models.ClientDTO() { Id = source.Client.Id, Name = source.Client.Name },
             new Models.GoodsDTO() { Id = source.Goods.Id, Name = source.Goods.Name },
             new Models.ManagerDTO() { Id = source.ManagerId, FirstName = source.Manager.FirstName, SecondName = source.Manager.SecondName },
             source.Cost
             );
           
       }

        public void Update(SalesDTO item)
        {
            var itm = context.SalesSet.FirstOrDefault(x => x.Id == item.Id);
            if (itm != null)
            {
                itm = ToEntity(item);
                context.Entry(itm).State = EntityState.Modified;
            }
        }

        public void Add(SalesDTO item)
        {
            _saleslist.Add(item);
        }

        public void Clear()
        {
            _saleslist.Clear();
        }

        public IEnumerable<SalesDTO> Items
        {
            get
            {
                var sales = new List<SalesDTO>();
                foreach (var s in this.context.SalesSet)
                {
                    sales.Add(ToObject(s));
                }
                return sales;
            }
        }
       
        public int Count
        {
            get { return _saleslist.Count; }
        }


        public void Remove(SalesDTO item)
        {
           
                var e = this.ToEntity(item);

                //context.SalesSet.Attach(e);
                //var s = context.SalesSet.FirstOrDefault(x => x.Id == e.Id);
                context.SalesSet.Remove(e);
          }






        public void SaveSales()
        {
            
                var list = _saleslist.Select(sales => ToEntity(sales)).ToList();
                context.SalesSet.AddRange(list);
                context.SaveChanges();
         
        }

    }
}
