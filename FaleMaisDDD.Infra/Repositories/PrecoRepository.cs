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
    public class PrecoRepository : BaseRepository<Preco>, IPrecoRepository
    {
        public PrecoRepository(DataContext db)
            : base(db)
        {

        }
    }
}
