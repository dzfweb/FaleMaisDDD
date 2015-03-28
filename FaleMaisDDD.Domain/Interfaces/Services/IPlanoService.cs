using FaleMaisDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Domain.Interfaces.Services
{
    public interface IPlanoService
    {
        Plano BuscarPorId(Guid id);
        IEnumerable<Plano> BuscarTodos();
        void AdicionarNovo(Plano plano);
        void Atualizar(Plano plano);
        void Excluir(Plano plano);
    }
}
