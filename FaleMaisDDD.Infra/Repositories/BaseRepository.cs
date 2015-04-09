using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaleMaisDDD.Domain.Entities;
using FaleMaisDDD.Domain.Interfaces.Repositories;
using FaleMaisDDD.Infra.Data;
using System.Data.Entity;

namespace FaleMaisDDD.Infra.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {

        protected readonly DataContext db;
        public BaseRepository(DataContext _db)
        {
            db = _db;
        }
        public void Add(TEntity obj)
        {
            db.Set<TEntity>().Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Remove(TEntity obj)
        {
            db.Set<TEntity>().Remove(obj);

        }
        public IEnumerable<TEntity> Find(Func<TEntity, bool> expr)
        {
            return db.Set<TEntity>().Where(expr);
        }

        public TEntity Get(Func<TEntity, bool> expr)
        {
            return db.Set<TEntity>().FirstOrDefault(expr);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
