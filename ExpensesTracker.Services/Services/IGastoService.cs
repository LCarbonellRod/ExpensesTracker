using ExpensesTrackerCore.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpensesTracker.Services.Services
{
    public interface IGastoService
    {
        Task<IEnumerable<Gasto>> GetAllGastos(string userId);
        Task<Gasto> GetGastoById(Guid id, string userId);
        Task<Gasto> CreateGasto(Gasto newGasto, string userId);
        Task<int> UpdateGasto(Gasto gastoToBeUpdated, Gasto newGasto);
        Task DeleteGasto(Gasto gasto);
    }
}
