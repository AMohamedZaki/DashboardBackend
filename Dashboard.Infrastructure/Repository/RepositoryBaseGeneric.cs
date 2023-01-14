using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dashboard.Infrastructure.Data;
using Dashboard.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.Repository
{
    public class RepositoryBaseGeneric<T>: IRepository<T> where T : class
    {
        #region Properties
        private readonly DbSet<T> dbSet;

        #endregion

        protected AppDbContext DbContext { get; set; }
        protected RepositoryBaseGeneric(AppDbContext context)
        {
            DbContext = context;
            dbSet = DbContext.Set<T>();
        }

        #region Implementation
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            DbContext.Set<T>().RemoveRange(entities);
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetById(int id) => dbSet.Find(id);
        public virtual T GetById<TY>(TY id) => dbSet.Find(id);
        public virtual IEnumerable<T> GetAll() => dbSet.ToList();
        public virtual IQueryable<T> GetQuerable() => dbSet.AsQueryable();
        public virtual DbSet<T> GetDbSet() => dbSet;
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where) => dbSet.Where(where).ToList();
        public T Get(Expression<Func<T, bool>> where) => dbSet.FirstOrDefault(where);
        public int SaveDbChanges()
        {
            return DbContext.SaveChanges();
        }
        #endregion
    }
}
