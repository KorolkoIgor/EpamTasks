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
       
        protected SalesDataModel.DataModelContainer1 context = new SalesDataModel.DataModelContainer1();
       
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
