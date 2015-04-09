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
    public class DDDRepository : BaseRepository<DDD>, IDDDRepository
    {
        public DDDRepository(DataContext db)
            :base(db)
        {

        }
        public IEnumerable<DDD> Ativos()
        {
            return db.DDDs.Where(p => p.Ativo);
        }
    }
}
