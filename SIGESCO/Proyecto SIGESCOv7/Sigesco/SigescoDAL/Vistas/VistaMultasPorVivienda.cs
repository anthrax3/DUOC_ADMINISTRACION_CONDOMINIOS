using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SigescoDAL.Vistas
{
    public class VistaMultasPorVivienda
    {
        public string DESCRIPCION { get; set; }
        public Nullable<System.DateTime> FECHA_GASTO { get; set; }
        public string NUMERO { get; set; }
        public string NOMBRE_CALLE { get; set; }
        public Nullable<decimal> MONTO_GASTO { get; set; }
        public string ESTADO { get; set; }
    }
}
