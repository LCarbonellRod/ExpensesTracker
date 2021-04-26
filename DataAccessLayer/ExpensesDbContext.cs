using DataAccessLayer.Configurations;
using ExpensesTrackerCore.Models;
using ExpensesTrackerCore.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class ExpensesDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }

        public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .ApplyConfiguration(new GastoConfigurations());

            builder
                .ApplyConfiguration(new CuotaConfigurations());
        }
    }
}
