using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigescoDAL.Vistas
{
    public class VistaMorosidadPorCondominio
    {
        public string NOMBRE { get; set; }
        public string NUMERO { get; set; }
        public string NOMBRE_CALLE { get; set; }
        public string PLANTA_UBICACION { get; set; }
        public decimal ID_GASTO { get; set; }
        public string NOMBRE_GASTO { get; set; }
        public Nullable<System.DateTime> FECHA_GASTO { get; set; }
        public Nullable<decimal> MONTO_GASTO { get; set; }
    }
}
