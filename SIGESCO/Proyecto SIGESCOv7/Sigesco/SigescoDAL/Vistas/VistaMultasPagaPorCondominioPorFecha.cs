using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigescoDAL.Vistas
{
    public class VistaMultasPagaPorCondominioPorFecha
    {
        public Nullable<System.DateTime> FECHA_GASTO { get; set; }
        public string NUMERO { get; set; }
        public string NOMBRE_CALLE { get; set; }
        public string PLANTA_UBICACION { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<decimal> MONTO_GASTO { get; set; }
        public string DOCUMENTO { get; set; }
        public string DESCRIPCION_TIPO { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
    }
}
