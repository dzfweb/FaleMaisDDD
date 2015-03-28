using FaleMaisDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Domain.Interfaces.Repositories
{
    public interface IAdministradorRepository : IBaseRepository<Administrador>, IDisposable
    {
        IEnumerable<Administrador> Ativos();
        Administrador GetByLoginAndPass(string login, string pass);
    }
}
