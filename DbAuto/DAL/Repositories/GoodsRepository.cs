using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class GoodsRepository : IRepository<DAL.Models.Goods>
    {
        private SalesDataModel.DataModelContainer1 context = new SalesDataModel.DataModelContainer1();

        private SalesDataModel.Goods ToEntity(DAL.Models.Goods source)
        {
            return new SalesDataModel.Goods() { Id = source.Id, Name = source.Name };
        }

        private DAL.Models.Goods ToObject(SalesDataModel.Goods source)
        {
            return new DAL.Models.Goods() { Id = source.Id, Name = source.Name };
        }

        public void Add(Models.Goods item)
        {
            var e = this.ToEntity(item);
            context.GoodsSet.Add(e);
        }

        public void Remove(Models.Goods item)
        {
            var e = this.ToEntity(item);
            context.GoodsSet.Remove(e);
        }

        public void Update(Models.Goods item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Goods> Items
        {
            get
            {
                foreach (var g in this.context.GoodsSet)
                {
                    yield return this.ToObject(g);
                }
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public int Count
        {
            get { return this.context.GoodsSet.Count(); }
        }
    }
}
