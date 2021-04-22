using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesTrackerCore.Models
{
    public class Cuota
    {
        public Guid Id { get; set; }
        public int CuotaNumero { get; set; }
        public bool CuotaPagada { get; set; }
        public DateTime FechaCreacion { get; set; }
        public decimal ValorCuota { get; set; }
        public DateTime FechaPagado { get; set; }

        public Guid GastoId { get; set; }
        public Gasto Gasto { get; set; }
    }
}
