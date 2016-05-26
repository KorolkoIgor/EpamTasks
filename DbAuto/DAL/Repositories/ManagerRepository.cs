using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class ManagerRepository : IRepository<DAL.Models.Manager>
    {
        private SalesDataModel.DataModelContainer1 context = new SalesDataModel.DataModelContainer1();

        private SalesDataModel.Manager ToEntity(DAL.Models.Manager source)
        {
            return new SalesDataModel.Manager() { Id = source.Id, FirstName = source.FirstName, SecondName = source.SecondName };
        }

        private DAL.Models.Manager ToObject(SalesDataModel.Manager source)
        {
            return new DAL.Models.Manager() { Id = source.Id, FirstName = source.FirstName, SecondName = source.SecondName };
        }

        public void Add(Models.Manager item)
        {
            var e = this.ToEntity(item);
            context.ManagerSet.Add(e);
        }

        public void Remove(Models.Manager item)
        {
            var e = this.ToEntity(item);
            context.ManagerSet.Remove(e);
        }

        public void Update(Models.Manager item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Manager> Items
        {
            get
            {
                foreach (var m in this.context.ManagerSet)
                {
                    yield return this.ToObject(m);
                }
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public int Count
        {
            get { return this.context.ManagerSet.Count(); }
        }
    }
}
