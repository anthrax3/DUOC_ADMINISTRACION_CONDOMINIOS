using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigescoDAL.Vistas
{
    public class VistaInfoResidentesPorCondominio
    {
        public string NUMERO { get; set; }
        public string NOMBRE_CALLE { get; set; }
        public decimal RUT { get; set; }
        public string PRIMER_NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public Nullable<decimal> TELEFONO { get; set; }
        public string CORREO { get; set; }
        public string DESCRIPCION_TIPO { get; set; }

    }
}
