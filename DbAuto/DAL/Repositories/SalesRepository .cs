using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DAL.Repositories
{
    public class SalesRepository : IRepository<DAL.Models.Sales>
    {
        private SalesDataModel.DataModelContainer1 context = new SalesDataModel.DataModelContainer1();
        //private SalesDataModel.DataModelContainer1 contextt = new SalesDataModel.DataModelContainer();
        private SalesDataModel.Sales ToEntity(DAL.Models.Sales source)
        {
            return new SalesDataModel.Sales()
            {
                Id=source.Id,
                Date = source.Date,
                ManagerId = source.ManagerId,
                ClientId = source.ClientId,
                GoodsId = source.GoodsId,
                Cost = source.Cost
            };
        }

        private DAL.Models.Sales ToObject(SalesDataModel.Sales source)
        {
            return new DAL.Models.Sales()
            {

                Id=source.Id,
                Date = source.Date,
                ManagerId =  source.ManagerId, 
                ClientId =source.ClientId,
                GoodsId =  source.GoodsId,
                Cost = source.Cost
            };
        }

        public void Add(Models.Sales item)
        {
            var e = this.ToEntity(item);
            context.SalesSet.Add(e);
        }

        public void Remove(Models.Sales item)
        {
            var e = this.ToEntity(item);
            context.SalesSet.Remove(e);
        }

        public void Update(Models.Sales item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Sales> Items
        {
            get
            {
                foreach (var s in this.context.SalesSet)
                {
                    yield return this.ToObject(s);
                }
            }
        }

        public void SaveChanges()
        {
            //contextt.SalesSet = context.SalesSet;
            try
            {

               // contextt.SaveChanges();
                context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int Count
        {
            get { return this.context.SalesSet.Count(); }
        }
    }
}
