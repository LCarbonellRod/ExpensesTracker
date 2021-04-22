using ExpensesTrackerCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpensesTracker.Services.Services
{
    public interface IGastoService
    {
        Task<IEnumerable<Gasto>> GetAllGastos();
        Task<Gasto> GetGastoById(int id);
        Task<Gasto> CreateGasto(Gasto newGasto);
        Task UpdateGasto(Gasto gastoToBeUpdated, Gasto gasto);
        Task DeleteGasto(Gasto gasto);
    }
}
