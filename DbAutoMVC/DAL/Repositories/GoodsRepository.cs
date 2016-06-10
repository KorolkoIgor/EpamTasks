using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using DAL.Models;
using SalesDataModel;

namespace DAL.Repositories
{
    public class GoodsRepository : AbstractRepository, IRepository<GoodsDTO>
    {
       private Goods ToEntity(GoodsDTO source)
        {
            return new Goods() { Id = source.Id, Name = source.Name };
        }

        private GoodsDTO ToObject(Goods source)
        {
            return new GoodsDTO() { Id = source.Id, Name = source.Name };
        }

        public void Add(GoodsDTO item)
        {
            var e = this.ToEntity(item);
            context.GoodsSet.Add(e);
        }

        public void Remove(GoodsDTO item)
        {
            var e = this.ToEntity(item);
            context.GoodsSet.Remove(e);
        }

        public void Update(GoodsDTO item)
        {
            var itm = context.GoodsSet.FirstOrDefault(x => x.Id == item.Id);
            if (itm != null)
            {
                itm.Name = item.Name;
                context.Entry(itm).State = EntityState.Modified;
            }
        }


        public IEnumerable<GoodsDTO> Items
        {
            get
            {
                foreach (var g in this.context.GoodsSet)
                {
                    yield return this.ToObject(g);
                }
            }
        }

        public void SaveSales()
        {
            this.context.SaveChanges();
        }

        public int Count
        {
            get { return this.context.GoodsSet.Count(); }
        }
    }
}
