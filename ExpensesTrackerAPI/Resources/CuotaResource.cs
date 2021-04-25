using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackerAPI.Resources
{
    public class CuotaResource
    {
        public Guid Id { get; set; }
        public int CuotaNumero { get; set; }
        public bool CuotaPagada { get; set; }
        public DateTime FechaCreacion { get; set; }
        public decimal ValorCuota { get; set; }
        public DateTime? FechaPagado { get; set; }

        public GastoResource Gasto { get; set; }
    }
}
