using FaleMaisDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Domain.Interfaces.Services
{
    public interface IDDDService
    {
        DDD BuscarPorId(Guid id);
        IEnumerable<DDD> BuscarTodos();
        IEnumerable<DDD> BuscarTodosAtivos();
        void AdicionarNovo(DDD ddd);
        void Atualizar(DDD ddd);
        void Excluir(DDD ddd);
    }
}
