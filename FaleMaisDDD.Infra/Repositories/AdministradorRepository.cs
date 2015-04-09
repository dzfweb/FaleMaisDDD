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
    public class AdministradorRepository : BaseRepository<Administrador>, IAdministradorRepository
    {
        public AdministradorRepository(DataContext db)
            : base(db)
        {

        }
        public IEnumerable<Administrador> Ativos()
        {
            return db.Administradores.Where(p => p.Ativo).ToList();
        }

        public Administrador GetByLoginAndPass(string login, string pass)
        {
            return db.Administradores.FirstOrDefault(p => p.Login == login && p.Senha == pass);
        }
    }
}
