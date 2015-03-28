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
    public class PrecoMap : EntityTypeConfiguration<Preco>
    {
        public PrecoMap()
        {
            
            ToTable("Preco");

            
            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            this
                .HasRequired<DDD>(p => p.Origem)
                .WithMany(p => p.Origem)
                .HasForeignKey(p => p.IdOrigem);      
          
            this
                .HasRequired<DDD>(p => p.Destino)
                .WithMany(p => p.Destino)
                .HasForeignKey(p => p.IdDestino); 
                
                        
        }

    }
}
