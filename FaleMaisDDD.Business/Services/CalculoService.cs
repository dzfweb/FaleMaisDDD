﻿using FaleMaisDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaleMaisDDD.Domain.Models;
using FaleMaisDDD.Domain.Interfaces.Repositories;
using FaleMaisDDD.Domain.Entities;

namespace FaleMaisDDD.Business.Services
{
    public class CalculoService : ServiceBase, ICalculoService
    {
        private IPlanoService _planoService;
        private IPrecoService _precoService;
        private IDDDService _dddService;
        private IUnitOfWorkService _uow;

        public CalculoService(IUnitOfWorkService uow)  
            : base(uow)
        {
            this._uow = uow;
            this._dddService = uow.Service<IDDDService>();
            this._planoService = uow.Service<IPlanoService>();;
            this._precoService = uow.Service<IPrecoService>();
        }
        public ResultadoCalculo CalcularValores(PedidoCalculo pedido)
        {
            var resultado = new ResultadoCalculo();

            var listDDD = _dddService.Ativos();
            var objPlano = _planoService.Find(p => p.Id == pedido.PlanoID).FirstOrDefault();
            var objOrigem = listDDD.Where(p => p.Codigo == pedido.Origem).FirstOrDefault() ?? new DDD();
            var objDestino = listDDD.Where(p => p.Codigo == pedido.Destino).FirstOrDefault() ?? new DDD();
            var objPreco = _precoService.BuscarOrigemDestino(objOrigem, objDestino);

            resultado.Plano = PreencherPlano(objPlano);
            resultado.Origem = PreencherOrigem(objOrigem);
            resultado.Destino = PreencherDestino(objDestino);

            if (objPreco != null && objPlano.Ativo)
            {
                resultado.Detalhe.Sucesso = true;
                decimal valorComPlano = 0;
                decimal valorSemPlano = 0;
                decimal tempoExcedido = pedido.Tempo - objPlano.Minutos;

                valorComPlano = tempoExcedido > 0 ? (tempoExcedido * ((objPreco.ValorMinuto * (objPlano.TarifaExcedente / 100)) + objPreco.ValorMinuto)) : 0;
                valorSemPlano = pedido.Tempo * objPreco.ValorMinuto;

                resultado.Detalhe.Tempo = pedido.Tempo;
                resultado.Detalhe.ValorComPlano = valorComPlano;
                resultado.Detalhe.ValorSemPlano = valorSemPlano;

            }
            else
            {
                resultado.Detalhe.Sucesso = false;
            }

            return resultado;
        }

        private DDD PreencherDestino(DDD destino)
        {
            return new DDD()
            {
                Id = destino.Id,
                Ativo = destino.Ativo,
                Codigo = destino.Codigo
            };
        }

        private DDD PreencherOrigem(DDD origem)
        {
            return new DDD()
            {
                Id = origem.Id,
                Ativo = origem.Ativo,
                Codigo = origem.Codigo
            };
        }

        private Plano PreencherPlano(Plano plano)
        {
            return new Plano()
            {
                Id = plano.Id,
                Minutos = plano.Minutos,
                Descricao = plano.Descricao,
                Preco = plano.Preco,
                Ativo = plano.Ativo,
                TarifaExcedente = plano.TarifaExcedente
            };
        }

        public void Dispose()
        {
            //nothing
        }
    }
}
