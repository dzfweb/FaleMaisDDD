using FaleMaisDDD.Domain.Entities;
using FaleMaisDDD.Domain.Interfaces.Repositories;
using FaleMaisDDD.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Infra.Repositories
{
    public class DDDRepository : IDDDRepository
    {
        private DataContext _context;

        public DDDRepository(DataContext context)
        {
            this._context = context;
        }
        public void Add(DDD obj)
        {
            _context.DDDs.Add(obj);
            _context.SaveChanges();
        }

        public DDD GetById(Guid id)
        {
            return _context.DDDs.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<DDD> GetAll()
        {
            return _context.DDDs.ToList();
        }

        public void Update(DDD obj)
        {
            _context.Entry<DDD>(obj).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(DDD obj)
        {
            _context.DDDs.Remove(obj);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
