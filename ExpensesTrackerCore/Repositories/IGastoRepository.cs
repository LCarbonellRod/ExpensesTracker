using ExpensesTrackerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTrackerCore.Repositories
{
    public interface IGastoRepository : IRepository<Gasto>
    {
        Task<IEnumerable<Gasto>> GetAllWithCuotasAsync(string userId);

        Task<IEnumerable<Gasto>> GetAllAsync(string userId);

        Task<Gasto> GetWithCuotasByIdAsync(Guid id, string userId);
    }
}
