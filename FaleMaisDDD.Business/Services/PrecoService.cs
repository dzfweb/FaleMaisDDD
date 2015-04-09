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
    public class PrecoService : DataServiceBase<Preco>, IPrecoService
    {
        
        private IUnitOfWorkService _uow;
        private IPrecoRepository _precoRepository;
        public PrecoService(UnitOfWorkService uow)
            : base(uow)
        {
            this._uow = uow;
            this._precoRepository = uow.Repository<IPrecoRepository>();
        }
        public Preco BuscarOrigemDestino(DDD origem, DDD destino)
        {
            return _precoRepository.GetAll().Where(p => p.IdDestino == destino.Id && p.IdOrigem == origem.Id).FirstOrDefault();
        }
    }
}
