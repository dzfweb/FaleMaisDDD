using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using FaleMaisDDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure.Annotations;

namespace FaleMaisDDD.Infra.Data.Map
{
    public class DDDMap : EntityTypeConfiguration<DDD>
    {
        public DDDMap()
        {
            
            ToTable("DDD");

            
            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this
                .HasMany<Preco>(p => p.Origem)
                .WithRequired(p => p.Origem)
                .HasForeignKey(p => p.IdOrigem).WillCascadeOnDelete(false);

            this
                .HasMany<Preco>(p => p.Destino)
                .WithRequired(p => p.Destino)
                .HasForeignKey(p => p.IdDestino).WillCascadeOnDelete(false);         
                
            
        }

    }
}
