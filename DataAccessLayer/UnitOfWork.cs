using DataAccessLayer.Repositories;
using ExpensesTrackerCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExpensesDbContext _context;
        private CuotaRepository _cuotaRepository;
        private GastoRepository _gastoRepository;

        public UnitOfWork(ExpensesDbContext context)
        {
            this._context = context;
        }

        public ICuotaRepository Cuotas => _cuotaRepository = _cuotaRepository ?? new CuotaRepository(_context);

        public IGastoRepository Gastos => _gastoRepository = _gastoRepository ?? new GastoRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
