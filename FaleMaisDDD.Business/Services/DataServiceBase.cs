using FaleMaisDDD.Domain.Interfaces.Repositories;
using FaleMaisDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Business.Services
{
    public class DataServiceBase<TEntity> : ServiceBase, IDisposable, IDataServiceBase<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IUnitOfWorkService _uow;

        public DataServiceBase(UnitOfWorkService uow)
            : base(uow)
        {
            _uow = uow;
            _repository = uow.Repository<IBaseRepository<TEntity>>();
        }
        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> expr)
        {
            return _repository.Find(expr);

        }

        public TEntity Get(Func<TEntity, bool> expr)
        {
            return _repository.Get(expr);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
