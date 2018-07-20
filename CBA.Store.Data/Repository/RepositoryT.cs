using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CBA.Store.Data.Context;
using CBA.Store.Data.Interface;

namespace CBA.Store.Data.Repository
{
    /// <summary>
    /// Base repository that provides CRUD EF operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T>
          where T : class
    {
        protected EntityContext EntityContext;

        public Repository(EntityContext context)
        {
            EntityContext = context;
        }

        public virtual T Get(long id)
        {
            return EntityContext.Set<T>().Find(id);
        }

        public virtual List<T> GetAll()
        {
            return EntityContext.Set<T>().ToList();
        }

        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    EntityContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
