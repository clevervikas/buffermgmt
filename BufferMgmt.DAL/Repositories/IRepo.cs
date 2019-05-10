using System.Collections.Generic;

namespace BufferMgmt.DAL.Repositories
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
