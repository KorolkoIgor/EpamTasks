using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using DAL.Models;
using SalesDataModel;

namespace DAL.Repositories
{
    public class ManagerRepository : AbstractRepository, IRepository<ManagerDTO>
    {
        private Manager ToEntity(ManagerDTO source)
        {
            return new Manager() { Id = source.Id, FirstName = source.FirstName, SecondName = source.SecondName };
        }

        private ManagerDTO ToObject(Manager source)
        {
            return new ManagerDTO() { Id = source.Id, FirstName = source.FirstName, SecondName = source.SecondName };
        }

        public void Add(ManagerDTO item)
        {
            var e = this.ToEntity(item);
            context.ManagerSet.Add(e);
        }

        public void Remove(ManagerDTO item)
        {
            var e = this.ToEntity(item);
            context.ManagerSet.Remove(e);
        }

        public IEnumerable<ManagerDTO> Items
        {
            get
            {
                foreach (var m in this.context.ManagerSet)
                {
                    yield return this.ToObject(m);
                }
            }
        }

        public void SaveSales()
        {
            context.SaveChanges();
        }

        public int Count
        {
            get { return this.context.ManagerSet.Count(); }
        }
    }
}
