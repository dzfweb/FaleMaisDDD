using FaleMaisDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Domain.Models
{
   public class ResultadoCalculo
    {
        public DDD Origem { get; set; }
        public DDD Destino { get; set; }
        public Plano Plano { get; set; }
        public DetalheResultado Detalhe { get; set; }

        public ResultadoCalculo()
        {
            this.Detalhe = new DetalheResultado();
        }
        
    }
}
