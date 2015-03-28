using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Domain.Entities
{
    public class Preco
    {
        public Guid Id { get; set; }
        
        public decimal ValorMinuto { get; set; }
       
        public bool Ativo { get; set; }
      
        public Guid IdOrigem { get; set; }
       
        public Guid IdDestino { get; set; }
        
        public virtual DDD Origem { get; set; }
        
       
        public virtual DDD Destino { get; set; }
    }
}
