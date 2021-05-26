using ExpensesTrackerCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Configurations
{
    public class GastoConfigurations : IEntityTypeConfiguration<Gasto>
    {
        public void Configure(EntityTypeBuilder<Gasto> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.CantidadCuotas)
                .IsRequired();

            builder
                .Property(m => m.FechaCreacion)
                .IsRequired();

            builder
                .Property(m => m.Nombre)
                .IsRequired();

            builder
                .Property(m => m.Valor)
                .IsRequired();

            builder
                .Property(m => m.UserId)
                .IsRequired();

            builder
                .ToTable("Gasto");
        }
    }
}
