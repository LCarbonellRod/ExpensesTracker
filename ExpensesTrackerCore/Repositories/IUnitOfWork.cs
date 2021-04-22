using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTrackerCore.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGastoRepository Gastos { get; }
        ICuotaRepository Cuotas { get; }
        Task<int> CommitAsync();
    }
}
