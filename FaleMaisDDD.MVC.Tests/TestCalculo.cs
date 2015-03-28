using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FaleMaisDDD.Domain.Models;
using FaleMaisDDD.Infra.Repositories;

namespace FaleMaisDDD.MVC.Tests
{
    [TestClass]
    public class TestCalculo
    {
                
        [TestMethod]
        public void TestMethod1()
        {
            public void CalculoDeTarifas_SituacaoUm()
        {
            //pedido de calculo
            var pedidoCalculo = new PedidoCalculo();
            pedidoCalculo.Tempo = 20;
            pedidoCalculo.Origem = 11;
            pedidoCalculo.Destino = 16;
            pedidoCalculo.PlanoID = ; //plano FaleMais30

            //resultado experado
            var detalhe = new DetalheResultado();
            detalhe.Sucesso = true;
            detalhe.Tempo = 20;
            detalhe.ValorComPlano = 0;
            detalhe.ValorSemPlano = 38;
                        
            var _calculos = new Calculos();
            ResultadoCalculo tarifa = _calculos.CalcularTarifa(pedidoCalculo);

            Assert.AreEqual(detalhe.Tempo, tarifa.Detalhe.Tempo, "Tempo Retornado diferente do experado.");
            Assert.AreEqual(detalhe.ValorComPlano, tarifa.Detalhe.ValorComPlano, "Valor com Plano retornado diferente do experado.");
            Assert.AreEqual(detalhe.ValorSemPlano, tarifa.Detalhe.ValorSemPlano, "Valor sem Plano retornado diferente do experado");

        }
        }
    }
}
