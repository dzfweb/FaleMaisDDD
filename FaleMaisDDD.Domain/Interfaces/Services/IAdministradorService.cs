using FaleMaisDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Domain.Interfaces.Services
{
    public interface IAdministradorService
    {
        Administrador BuscarPorId(Guid id);
        IEnumerable<Administrador> BuscarTodos();
        void AdicionarNovo(Administrador administrador);
        void Atualizar(Administrador administrador);
        void Excluir(Administrador administrador);
        bool Autenticar(string login, string senha);
    }
}
