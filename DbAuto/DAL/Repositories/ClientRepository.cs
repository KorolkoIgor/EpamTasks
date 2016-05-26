using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class ClientRepository : IRepository<DAL.Models.Client>
    {
        private SalesDataModel.DataModelContainer1 context = new SalesDataModel.DataModelContainer1();

        private SalesDataModel.Client ToEntity(DAL.Models.Client source)
        {
            return new SalesDataModel.Client() { Id = source.Id, Name = source.Name };
        }

        private DAL.Models.Client ToObject(SalesDataModel.Client source)
        {
            return new DAL.Models.Client() { Id = source.Id, Name = source.Name };
        }

        public void Add(Models.Client item)
        {
            var e = this.ToEntity(item);
            context.ClientSet.Add(e);
        }

        public void Remove(Models.Client item)
        {
            var e = this.ToEntity(item);
            context.ClientSet.Remove(e);
        }

        public void Update(Models.Client item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Client> Items
        {
            get
            {
                foreach (var c in this.context.ClientSet)
                {
                    yield return this.ToObject(c);
                }
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public int Count
        {
            get { return this.context.ClientSet.Count(); }
        }
    }
}
