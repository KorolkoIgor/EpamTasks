using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DAL.Models;
using SalesDataModel;

namespace DAL.Repositories
{
    public class SalesRepository : AbstractRepository, IRepository<SalesDTO>
    {
        public readonly ICollection<SalesDTO> _saleslist = new List<SalesDTO>();

       public Sales ToEntity(SalesDTO sourse)
        {
            var sales = new Sales()
            {
                Date = sourse.Date,
                ClientId = sourse.ClientId,
                GoodsId = sourse.GoodsId,
                ManagerId = sourse.ManagerId,
                Cost = sourse.Cost
            };
            return sales;
        }

        private SalesDTO ToObject(SalesDataModel.Sales source)
        {
      return new SalesDTO(source.Date, source.ManagerId, source.ClientId, source.GoodsId, source.Cost);
            
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
                foreach (var s in this.context.SalesSet)
                {
                    yield return this.ToObject(s);
                }
            }
        }
       
        public int Count
        {
            get { return _saleslist.Count; }
        }
              
        public void Remove(SalesDTO item)
        {
             _saleslist.Remove(item);
        }

        public void SaveSales()
        {
            try
            {
                var list = _saleslist.Select(sales => ToEntity(sales)).ToList();
                context.SalesSet.AddRange(list);
                context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
