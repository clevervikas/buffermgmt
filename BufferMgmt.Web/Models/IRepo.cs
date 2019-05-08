using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BufferMgmt.Web.Models
{
   public interface IRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
