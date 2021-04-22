using ExpensesTrackerCore.Models;
using ExpensesTrackerCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GastoRepository : Repository<Gasto>, IGastoRepository
    {
        public GastoRepository(ExpensesDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Gasto>> GetAllWithCuotasAsync()
        {
            return await ExpensesDbContext.Gastos
                .Include(a => a.Cuotas)
                .ToListAsync();
        }

        public Task<Gasto> GetWithCuotasByIdAsync(Guid id)
        {
            return ExpensesDbContext.Gastos
                .Include(a => a.Cuotas)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private ExpensesDbContext ExpensesDbContext
        {
            get { return Context as ExpensesDbContext; }
        }
    }
}
