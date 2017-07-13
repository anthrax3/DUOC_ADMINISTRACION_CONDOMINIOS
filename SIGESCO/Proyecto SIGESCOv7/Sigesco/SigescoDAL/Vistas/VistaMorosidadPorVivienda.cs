using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SigescoDAL.Vistas
{
    public class VistaMorosidadPorVivienda
    {
        public string NOMBRE_GASTO { get; set; }
        public Nullable<System.DateTime> FECHA_GASTO { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<decimal> MONTO_GASTO { get; set; }
    }
}
