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
    public class PlanoService: IPlanoService
    {
        private IPlanoRepository _repository;
        public PlanoService(IPlanoRepository repository)
        {
            this._repository = repository;
        }
        public Plano BuscarPorId(Guid id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Plano> BuscarTodos()
        {
            return _repository.GetAll();
        }

        public void AdicionarNovo(Plano plano)
        {
            _repository.Add(plano);
        }

        public void Atualizar(Plano plano)
        {
            _repository.Update(plano);
        }

        public void Excluir(Plano plano)
        {
            _repository.Remove(plano);
        }
    }
}
