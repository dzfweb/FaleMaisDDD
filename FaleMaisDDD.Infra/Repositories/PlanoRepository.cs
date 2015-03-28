using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaleMaisDDD.Domain.Entities;
using FaleMaisDDD.Domain.Interfaces.Repositories;
using FaleMaisDDD.Infra.Data;

namespace FaleMaisDDD.Infra.Repositories
{
    public class PlanoRepository : IPlanoRepository
    {
        private DataContext _context;
        public PlanoRepository(DataContext context)
        {
            this._context = context;
        }
        public void Add(Plano obj)
        {
            _context.Planos.Add(obj);
            _context.SaveChanges();
        }

        public Plano GetById(Guid id)
        {
            return _context.Planos.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Plano> GetAll()
        {
            return _context.Planos.ToList();
        }

        public void Update(Plano obj)
        {
            _context.Entry<Plano>(obj).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Plano obj)
        {
            _context.Planos.Remove(obj);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
