using ExpensesTrackerCore.Models;
using ExpensesTrackerCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GastoRepository : Repository<Gasto>, IGastoRepository
    {
        public GastoRepository(ExpensesDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Gasto>> GetAllWithCuotasAsync(string userId)
        {
            return await ExpensesDbContext.Gastos
                .Where(x=>x.UserId == userId)
                .Include(a => a.Cuotas)
                .ToListAsync();
        }

        public Task<Gasto> GetWithCuotasByIdAsync(Guid id, string userId)
        {
            return ExpensesDbContext.Gastos
                .Where(x=> x.UserId == userId)
                .Include(a => a.Cuotas)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Gasto>> GetAllAsync(string userId)
        {
            return await ExpensesDbContext.Gastos.Where(x=>x.UserId == userId).ToListAsync();
        }

        private ExpensesDbContext ExpensesDbContext
        {
            get { return Context as ExpensesDbContext; }
        }
    }
}
