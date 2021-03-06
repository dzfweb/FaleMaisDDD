﻿using FaleMaisDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Domain.Interfaces.Repositories
{
    public interface IDDDRepository : IBaseRepository<DDD>
    {
        IEnumerable<DDD> Ativos();
    }
}
