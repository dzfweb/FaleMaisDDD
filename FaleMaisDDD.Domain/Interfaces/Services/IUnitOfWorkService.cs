using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Domain.Interfaces.Services
{
    public interface IUnitOfWorkService : IDisposable
    {
        void Commit();
        void RollBack();
        T Service<T>() where T : class;
        T Repository<T>() where T : class;
    }
}
