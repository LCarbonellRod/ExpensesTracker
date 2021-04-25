using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackerAPI.Resources
{
    public class GastoResource
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public decimal Valor { get; set; }
        public bool EsGastoFijo { get; set; }
        public int CantidadCuotas { get; set; }
        public bool GastoPagado { get; set; }
        public bool GastoInactivo { get; set; }
        public string RazonInactivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? DiaReactivacion { get; set; }
        public bool EsReactivable { get; set; }
        public DateTime? FechaPagado { get; set; }
        public DateTime FechaInicioPago { get; set; }
    }
}
