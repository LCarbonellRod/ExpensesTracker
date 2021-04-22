using ExpensesTrackerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTrackerCore.Repositories
{
    public interface IGastoRepository : IRepository<Gasto>
    {
        Task<IEnumerable<Gasto>> GetAllWithCuotasAsync();
    }
}
