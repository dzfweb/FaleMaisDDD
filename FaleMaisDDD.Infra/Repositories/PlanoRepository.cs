using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaleMaisDDD.Domain.Entities;
using FaleMaisDDD.Domain.Interfaces.Repositories;
using FaleMaisDDD.Infra.Data;

namespace FaleMaisDDD.Infra.Repositories
{
    public class PlanoRepository : BaseRepository<Plano>, IPlanoRepository
    {
        public PlanoRepository(DataContext db)
            : base(db)
        {

        }
    }
}
