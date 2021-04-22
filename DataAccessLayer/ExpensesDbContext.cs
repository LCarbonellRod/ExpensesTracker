using DataAccessLayer.Configurations;
using ExpensesTrackerCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class ExpensesDbContext : DbContext
    {
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }

        public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new GastoConfigurations());

            builder
                .ApplyConfiguration(new CuotaConfigurations());
        }
    }
}
