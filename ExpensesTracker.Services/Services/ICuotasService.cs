using ExpensesTrackerCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Services.Services
{
    public interface ICuotasService
    {
        Task<IEnumerable<Cuota>> GetAllWithGastos();
        Task<Cuota> GetCuotaById(int id);
        Task<IEnumerable<Cuota>> GetCuotasByGastoId(int gastoId);
        Task<Cuota> CreateCuota(Cuota newCuota);
        Task UpdateCuota(Cuota cuotaToBeUpdated, Cuota cuota);
        Task DeleteCuota(Cuota cuota);
    }
}
