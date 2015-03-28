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
    public class AdministradorRepository : IAdministradorRepository
    {
        private DataContext _context;

        public AdministradorRepository(DataContext context)
        {
            this._context = context;
        }

        public IEnumerable<Administrador> Ativos()
        {
            return _context.Administradores.Where(p => p.Ativo);
        }

        public Administrador GetByLoginAndPass(string login, string pass)
        {
            return _context.Administradores.FirstOrDefault(p => p.Login == login && p.Senha == pass);
        }

        public void Add(Administrador obj)
        {
            _context.Administradores.Add(obj);
            _context.SaveChanges();
        }

        public Administrador GetById(Guid id)
        {
            return _context.Administradores.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Administrador> GetAll()
        {
            return _context.Administradores.ToList();
        }

        public void Update(Administrador obj)
        {
            _context.Entry<Administrador>(obj).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Administrador obj)
        {
            _context.Administradores.Remove(obj);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
