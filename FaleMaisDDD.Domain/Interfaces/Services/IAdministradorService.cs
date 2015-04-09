using FaleMaisDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Domain.Interfaces.Services
{
    public interface IAdministradorService : IDataServiceBase<Administrador>
    {
        bool Autenticar(string login, string senha);
    }
}
