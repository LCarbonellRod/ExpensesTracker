// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(ExpensesDbContext))]
    [Migration("20210425031248_MakeSomePropertiesNullable")]
    partial class MakeSomePropertiesNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExpensesTrackerCore.Models.Cuota", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CuotaNumero")
                        .HasColumnType("int");

                    b.Property<bool>("CuotaPagada")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaPagado")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GastoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ValorCuota")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("GastoId");

                    b.ToTable("Cuota");
                });

            modelBuilder.Entity("ExpensesTrackerCore.Models.Gasto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CantidadCuotas")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DiaReactivacion")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EsGastoFijo")
                        .HasColumnType("bit");

                    b.Property<bool>("EsReactivable")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaPagado")
                        .HasColumnType("datetime2");

                    b.Property<bool>("GastoInactivo")
                        .HasColumnType("bit");

                    b.Property<bool>("GastoPagado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazonInactivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Gasto");
                });

            modelBuilder.Entity("ExpensesTrackerCore.Models.Cuota", b =>
                {
                    b.HasOne("ExpensesTrackerCore.Models.Gasto", "Gasto")
                        .WithMany("Cuotas")
                        .HasForeignKey("GastoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gasto");
                });

            modelBuilder.Entity("ExpensesTrackerCore.Models.Gasto", b =>
                {
                    b.Navigation("Cuotas");
                });
#pragma warning restore 612, 618
        }
    }
}
