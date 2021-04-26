using ExpensesTrackerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Services.Services
{
    public interface ICuotasService
    {
        Task<Cuota> GetCuotaById(Guid id);
        Task<IEnumerable<Cuota>> GetCuotasByGastoId(Guid gastoId);
        Task<Cuota> CreateCuota(Cuota newCuota);
        Task<int> UpdateCuota(Cuota cuotaToBeUpdated, Cuota newCuota);
        Task DeleteCuota(Cuota cuota);
    }
}
