using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Domain.Entities
{
    public class DDD
    {
        public DDD()
        {
            this.Id = Guid.NewGuid();
            this.Ativo = true;
        }
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<Preco> Origem { get; set; }
        public virtual ICollection<Preco> Destino { get; set; }
    }
}
