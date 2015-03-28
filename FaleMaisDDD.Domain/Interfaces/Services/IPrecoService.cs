using FaleMaisDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Domain.Interfaces.Services
{
    public interface IPrecoService
    {
        Preco BuscarPorId(Guid id);
        IEnumerable<Preco> BuscarTodos();
        void AdicionarNovo(Preco preco);
        void Atualizar(Preco preco);
        void Excluir(Preco preco);
        Preco BuscarOrigemDestino(DDD origem, DDD destino);
    }
}
