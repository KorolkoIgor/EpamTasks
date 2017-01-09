using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using DAL.Models;
using SalesDataModel;

namespace DAL.Repositories
{
    public class ClientRepository : AbstractRepository, IRepository<ClientDTO>
    {
        private Client ToEntity(ClientDTO source)
        {
            return new Client() { Id = source.Id, Name = source.Name };
        }

        private ClientDTO ToObject(Client source)
        {
            return new ClientDTO() { Id = source.Id, Name = source.Name };
        }

        public void Add(ClientDTO item)
        {
            var e = this.ToEntity(item);
            context.ClientSet.Add(e);
        }

        public void Remove(ClientDTO item)
        {
            var e = this.ToEntity(item);
            context.ClientSet.Remove(e);
        }

        public IEnumerable<ClientDTO> Items
        {
            get
            {
                foreach (var c in this.context.ClientSet)
                {
                    yield return this.ToObject(c);
                }
            }
        }

        public void SaveSales()
        {
            this.context.SaveChanges();
        }

        public int Count
        {
            get { return this.context.ClientSet.Count(); }
        }
    }
}
