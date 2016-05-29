using SalesDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class AbstractRepository:IDisposable
    { 
       
        protected DataModelContainer1 context = new DataModelContainer1();
       
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

       ~AbstractRepository()
        {
            Dispose(false);
        }
    }
 }
