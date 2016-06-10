using SalesDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public  class AbstractRepository:IDisposable
    {
        private bool disposed=false;
        public DataModelContainer1 context = new DataModelContainer1();
       
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
            
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }

       ~AbstractRepository()
        {
            Dispose(false);
        }
    }
}
