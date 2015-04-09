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
    public class DDDService : DataServiceBase<DDD>, IDDDService
    {
        private IUnitOfWorkService _uow;
        private IDDDRepository _dddRepository;
        public DDDService(UnitOfWorkService uow)
            : base(uow)
        {
             this._uow = uow;
             this._dddRepository = uow.Repository<IDDDRepository>();
        }
        public IEnumerable<DDD> Ativos()
        {
            return _dddRepository.Ativos();
        }
    }
}
