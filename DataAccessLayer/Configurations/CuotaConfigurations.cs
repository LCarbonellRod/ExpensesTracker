using ExpensesTrackerCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Configurations
{
    public class CuotaConfigurations : IEntityTypeConfiguration<Cuota>
    {
        public void Configure(EntityTypeBuilder<Cuota> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.CuotaNumero)
                .IsRequired();

            builder
                .Property(m => m.CuotaPagada)
                .IsRequired();

            builder
                .Property(m => m.FechaCreacion)
                .IsRequired();

            builder
                .Property(m => m.ValorCuota)
                .IsRequired();

            builder
                .HasOne(m => m.Gasto)
                .WithMany(a => a.Cuotas)
                .HasForeignKey(m => m.GastoId);

            builder
                .ToTable("Cuota");
        }
    }
}
