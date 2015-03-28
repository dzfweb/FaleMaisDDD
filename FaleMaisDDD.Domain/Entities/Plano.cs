using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMaisDDD.Domain.Entities
{
    public class Plano
    {
        public Plano()
        {
            this.Id = Guid.NewGuid();            
        }
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal Minutos { get; set; }
        public decimal Preco { get; set; }
        public decimal TarifaExcedente { get; set; }
        public bool Ativo { get; set; }
    }
}
