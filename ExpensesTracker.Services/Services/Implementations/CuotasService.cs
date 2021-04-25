using ExpensesTrackerCore.Models;
using ExpensesTrackerCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Services.Services.Implementations
{
    public class CuotasService : ICuotasService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CuotasService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Cuota> CreateCuota(Cuota newCuota)
        {
            await _unitOfWork.Cuotas.AddAsync(newCuota);
            await _unitOfWork.CommitAsync();
            return newCuota;
        }

        public async Task DeleteCuota(Cuota cuota)
        {
            _unitOfWork.Cuotas.Remove(cuota);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Cuota> GetCuotaById(Guid id)
        {
            return await _unitOfWork.Cuotas
               .GetByIdAsync(id);
        }

        public async Task<IEnumerable<Cuota>> GetCuotasByGastoId(Guid gastoId)
        {
            return await _unitOfWork.Cuotas
                .GetAllByGastoIdAsync(gastoId);
        }

        public async Task<int> UpdateCuota(Cuota cuotaToBeUpdated)
        {
            return await _unitOfWork.UpdateAsync(cuotaToBeUpdated);
        }
    }
}
