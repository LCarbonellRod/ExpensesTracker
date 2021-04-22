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
    public class CuotaRepository : Repository<Cuota>, ICuotaRepository
    {
        public CuotaRepository(ExpensesDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Cuota>> GetAllWithGastoAsync()
        {
            return await ExpensesDbContext.Cuotas
                .Include(m => m.Gasto)
                .ToListAsync();
        }

        public async Task<Cuota> GetWithGastoByIdAsync(Guid id)
        {
            return await ExpensesDbContext.Cuotas
                .Include(m => m.Gasto)
                .SingleOrDefaultAsync(m => m.Id == id); ;
        }

        public async Task<IEnumerable<Cuota>> GetAllWithGastoByGastoIdAsync(Guid gastoId)
        {
            return await ExpensesDbContext.Cuotas
                .Include(m => m.Gasto)
                .Where(m => m.GastoId == gastoId)
                .ToListAsync();
        }

        public Task<IEnumerable<Cuota>> GetAllByGastoIdAsync(int artistId)
        {
            throw new NotImplementedException();
        }

        private ExpensesDbContext ExpensesDbContext
        {
            get { return Context as ExpensesDbContext; }
        }
    }
}
