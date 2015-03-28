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
    public class PrecoRepository : IPrecoRepository
    {
        private DataContext _context;

        public PrecoRepository(DataContext context)
        {
            this._context = context;
        }
        public void Add(Preco obj)
        {
            _context.Precos.Add(obj);
            _context.SaveChanges();
        }

        public Preco GetById(Guid id)
        {
            return _context.Precos.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Preco> GetAll()
        {
            return _context.Precos.ToList();
        }

        public void Update(Preco obj)
        {
            _context.Entry<Preco>(obj).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Preco obj)
        {
            _context.Precos.Remove(obj);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
