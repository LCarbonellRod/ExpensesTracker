using ExpensesTrackerCore.Models;
using ExpensesTrackerCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Services.Services.Implementations
{
    public class GastoService : IGastoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GastoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Gasto> CreateGasto(Gasto newGasto)
        {
            await _unitOfWork.Gastos
                .AddAsync(newGasto);

            return newGasto;
        }

        public async Task DeleteGasto(Gasto gasto)
        {
            _unitOfWork.Gastos.Remove(gasto);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Gasto>> GetAllGastos()
        {
            return await _unitOfWork.Gastos.GetAllAsync();
        }

        public async Task<Gasto> GetGastoById(Guid id)
        {
            return await _unitOfWork.Gastos.GetByIdAsync(id);
        }

        public async Task<int> UpdateGasto(Gasto gastoToBeUpdated)
        {
            return await _unitOfWork.UpdateAsync(gastoToBeUpdated);
        }
    }
}
