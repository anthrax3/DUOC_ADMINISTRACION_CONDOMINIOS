using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SigescoDAL.Vistas
{
    public class VistaGastosPorVivienda
    {
        public string NOMBRE_GASTO { get; set; }
        public Nullable<System.DateTime> FECHA_GASTO { get; set; }
        public Nullable<decimal> MONTO_GASTO { get; set; }
        public string ESTADO { get; set; }
        public string OBSERVACION { get; set; }
        public decimal ID_GASTO { get; set; }
    }
}
