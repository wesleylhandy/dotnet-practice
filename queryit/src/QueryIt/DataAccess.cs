using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QueryIt
{
    public class EmployeeDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
    
    public interface IReadOnlyRepository<out T>: IDisposable
    {
        T FindById(int id);
        IQueryable<T> FindAll();
    }

    public interface IWriteOnlyRepository<in T>: IDisposable
    {
        void Add(T newEntity);
        void Delete(T entity);
        int Commit();
    }
    public interface IRepository<T> : IReadOnlyRepository<T>, IWriteOnlyRepository<T>
    {
    }

    public class SqlRepository<T> : IRepository<T> where T: class, IEntity
    {
        DbContext _ctx;
        DbSet<T> _set;
        public SqlRepository(DbContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<T>();
        }

        public void Add(T newEntity)
        {
            if (newEntity.IsValid())
            {
                _set.Add(newEntity);
            }
        }

        public int Commit()
        {
            return _ctx.SaveChanges();
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public IQueryable<T> FindAll()
        {
            return _set;
        }

        public T FindById(int id)
        {
            return _set.Find(id);
        }
    }
}