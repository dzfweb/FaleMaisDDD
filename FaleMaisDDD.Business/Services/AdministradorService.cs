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
    public class AdministradorService : IAdministradorService
    {
        private IAdministradorRepository _repository;
        public AdministradorService(IAdministradorRepository repository)
        {
            this._repository = repository;
        }
        public Administrador BuscarPorId(Guid id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Administrador> BuscarTodos()
        {
            return _repository.GetAll();
        }

        public void AdicionarNovo(Administrador administrador)
        {
            _repository.Add(administrador);
        }

        public void Atualizar(Administrador administrador)
        {
            _repository.Update(administrador);
        }

        public void Excluir(Administrador administrador)
        {
            _repository.Remove(administrador);
        }
        public bool Autenticar(string login, string senha)
        {
            return _repository.GetByLoginAndPass(login, senha) != null;
        }
    }
}
