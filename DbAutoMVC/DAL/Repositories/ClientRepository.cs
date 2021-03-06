﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using DAL.Models;
using SalesDataModel;

namespace DAL.Repositories
{
    public class ClientRepository :  IRepository<ClientDTO>
    {
        public DataModelContainer1 context = new DataModelContainer1();

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

        public void Update(ClientDTO item)
        {
            var itm = context.ClientSet.FirstOrDefault(x => x.Id == item.Id);
            if (itm != null)
            {
                itm.Name = item.Name;
                context.Entry(itm).State = EntityState.Modified;
            }
        }

        //public IEnumerable<ClientDTO> Getall
        //{
        //    get
        //    {
        //       context.ClientSetAl 
        //    }
        //}


        public IEnumerable<ClientDTO> Items
        {
            get
            {
                var client = new List<ClientDTO>();
                foreach (var c in this.context.ClientSet)
                {

                    client.Add(ToObject(c));
                   // yield return this.ToObject(c);
                }
                return client;
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
