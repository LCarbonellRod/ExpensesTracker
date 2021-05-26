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
        private readonly IGastoRepository _gastoRepository;
        public GastoService(IUnitOfWork unitOfWork, IGastoRepository gastoRepository)
        {
            this._unitOfWork = unitOfWork;
            _gastoRepository = gastoRepository;
        }

        public async Task<Gasto> CreateGasto(Gasto newGasto, string userId)
        {

            newGasto.FechaCreacion = DateTime.Now;
            newGasto.UserId = userId;

            await _unitOfWork.Gastos
                .AddAsync(newGasto);

            await _unitOfWork.CommitAsync();

            return newGasto;
        }

        public async Task DeleteGasto(Gasto gasto)
        {
            _unitOfWork.Gastos.Remove(gasto);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Gasto>> GetAllGastos(string userId)
        {
            return await _gastoRepository.GetAllAsync(userId);
        }

        public async Task<Gasto> GetGastoById(Guid id, string userId)
        {
            return await _gastoRepository.GetWithCuotasByIdAsync(id, userId);
        }

        public async Task<int> UpdateGasto(Gasto gastoToBeUpdated, Gasto newGasto)
        {
            gastoToBeUpdated.Nombre = newGasto.Nombre;
            gastoToBeUpdated.Valor = newGasto.Valor;
            gastoToBeUpdated.EsGastoFijo = newGasto.EsGastoFijo;
            gastoToBeUpdated.CantidadCuotas = newGasto.CantidadCuotas;
            gastoToBeUpdated.EsReactivable = newGasto.EsReactivable;
            gastoToBeUpdated.FechaInicioPago = newGasto.FechaInicioPago;

            return await _unitOfWork.CommitAsync();
        }
    }
}
