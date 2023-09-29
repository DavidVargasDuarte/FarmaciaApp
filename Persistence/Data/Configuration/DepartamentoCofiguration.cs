using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DepartamentoCofiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamento");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().HasMaxLength(3);
            builder.Property(p=> p.Nombre).IsRequired().HasMaxLength(20);

            builder.HasOne(p => p.Paises)
            .WithMany(p => p.Departamentos)
            .HasForeignKey(p => p.IdPaisFK);
        }
    }
}