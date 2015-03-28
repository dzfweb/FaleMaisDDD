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
    public class DDDService : IDDDService
    {
        private IDDDRepository _repository;

        public DDDService(IDDDRepository repository)
        {
            this._repository = repository;
        }

        public DDD BuscarPorId(Guid id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<DDD> BuscarTodos()
        {
            return _repository.GetAll();
        }

        public IEnumerable<DDD> BuscarTodosAtivos()
        {
            return _repository.GetAll().Where(p => p.Ativo);
        }

        public void AdicionarNovo(DDD ddd)
        {
            _repository.Add(ddd);
        }

        public void Atualizar(DDD ddd)
        {
            _repository.Update(ddd);
        }

        public void Excluir(DDD ddd)
        {
            _repository.Remove(ddd);
        }
    }
}
