using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SigescoDAL.Vistas
{
    public class VistaCondominiosPorUsuario
    {
        public Nullable<decimal> ID_CONDOMINIO { get; set; }
        public string NOMBRE { get; set; }
        public string DIRECCION { get; set; }
        public Nullable<decimal> NUMERO_DIRECCION { get; set; }
        public Nullable<decimal> TELEFONO { get; set; }
        public string NOMBRE_COMUNA { get; set; }
        public string NOMBRE_REGION { get; set; }
    }
}
