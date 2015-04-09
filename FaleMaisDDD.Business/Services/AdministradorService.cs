using FaleMaisDDD.Domain.Entities;
using FaleMaisDDD.Domain.Interfaces.Repositories;
using FaleMaisDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Business.Services
{
    public class AdministradorService : DataServiceBase<Administrador>, IAdministradorService
    {
        private IUnitOfWorkService _uow;
        private IAdministradorRepository _administradorRepository;

        public AdministradorService(UnitOfWorkService uow)
            : base(uow)
        {
             this._uow = uow;
             this._administradorRepository = uow.Repository<IAdministradorRepository>();
        }

        public bool Autenticar(string login, string senha)
        {
            return _administradorRepository.Find(p => p.Login == login && p.Senha == senha && p.Ativo).Any();
        }
    }
}
