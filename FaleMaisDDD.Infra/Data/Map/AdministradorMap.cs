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
    public class AdministradorMap : EntityTypeConfiguration<Administrador>
    {
        public AdministradorMap()
        {
            ToTable("Administrador");

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Login)
                .HasMaxLength(20)
                .HasColumnAnnotation(
                IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_LOGIN", 1) { IsUnique = true }))
                .IsRequired();

            Property(p => p.Senha)
                .HasMaxLength(16)
                .IsRequired();
        }

    }
}
