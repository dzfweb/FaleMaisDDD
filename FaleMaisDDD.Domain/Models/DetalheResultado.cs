using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Domain.Models
{
    public class DetalheResultado
    {
        public bool Sucesso { get; set; }
        public decimal Tempo { get; set; }
        public decimal ValorComPlano { get; set; }
        public decimal ValorSemPlano { get; set; }
    }
}
