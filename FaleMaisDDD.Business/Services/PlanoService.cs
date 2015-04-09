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
    public class PlanoService : DataServiceBase<Plano>, IPlanoService
    {
        private IUnitOfWorkService _uow;
        public PlanoService(UnitOfWorkService uow)
            : base(uow)
        {
             this._uow = uow;
        }
    }
}
