using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackerAPI.Resources
{
    public class SaveGastoResource
    {
        public string Nombre { get; set; }
        public decimal Valor { get; set; }
        public bool EsGastoFijo { get; set; }
        public int CantidadCuotas { get; set; }
        public bool EsReactivable { get; set; }
        public DateTime FechaInicioPago { get; set; }
    }
}
