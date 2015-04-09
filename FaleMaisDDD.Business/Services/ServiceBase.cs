using FaleMaisDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Business.Services
{
    public class ServiceBase : IServiceBase
    {
        private IUnitOfWorkService _uow;

        public ServiceBase(IUnitOfWorkService uow)
        {
            this._uow = uow;
        }
        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
