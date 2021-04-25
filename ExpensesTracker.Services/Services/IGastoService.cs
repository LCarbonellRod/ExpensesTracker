using ExpensesTrackerCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpensesTracker.Services.Services
{
    public interface IGastoService
    {
        Task<IEnumerable<Gasto>> GetAllGastos();
        Task<Gasto> GetGastoById(Guid id);
        Task<Gasto> CreateGasto(Gasto newGasto);
        Task<int> UpdateGasto(Gasto gastoToBeUpdated);
        Task DeleteGasto(Gasto gasto);
    }
}
