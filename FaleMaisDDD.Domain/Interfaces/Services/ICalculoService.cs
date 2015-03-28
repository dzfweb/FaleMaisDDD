using FaleMaisDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Domain.Interfaces.Services
{
    public interface ICalculoService : IDisposable
    {
        ResultadoCalculo CalcularValores(PedidoCalculo pedido);
    }
}
