using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using BufferMgmt.DAL.Entities;

namespace BufferMgmt.DAL.Repositories
{
    public class Repo<T> : IRepo<T> where T : class
    {
        readonly BufferMgmtContext _db;
        readonly DbSet<T> _table;

        public Repo(BufferMgmtContext db)
        {
            _db = db;
            _table = _db.Set<T>();

        }
        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }

        public T Get(long id)
        {
            return _table.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public void Update(T entity)
        {
            _table.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
