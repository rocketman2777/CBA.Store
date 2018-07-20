using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace CBA.Store.Data.Interface
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        T Get(long id);
        List<T> GetAll();
    }
}
