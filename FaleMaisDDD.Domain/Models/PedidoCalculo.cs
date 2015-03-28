using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Domain.Models
{
    public class PedidoCalculo
    {
        public Guid PlanoID { get; set; }
        public decimal Tempo { get; set; }
        public int Origem { get; set; }
        public int Destino { get; set; }
    }
}
