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
    public class PrecoService : IPrecoService
    {
        private IPrecoRepository _repository;
        public PrecoService(IPrecoRepository _repository)
        {
            this._repository = _repository;
        }
        public Preco BuscarPorId(Guid id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Preco> BuscarTodos()
        {
            return _repository.GetAll();
        }

        public void AdicionarNovo(Preco preco)
        {
            _repository.Add(preco);
        }

        public void Atualizar(Preco preco)
        {
            _repository.Update(preco);
        }

        public void Excluir(Preco preco)
        {
            _repository.Remove(preco);
        }
        public Preco BuscarOrigemDestino(DDD origem, DDD destino)
        {
            return _repository.GetAll().Where(p => p.IdDestino == destino.Id && p.IdOrigem == origem.Id).FirstOrDefault();
        }
    }
}
