using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SigescoDAL.Vistas
{
    public class VistaViviendasPorUsuario
    {
        public decimal ID_VIVIENDA { get; set; }
        public string NUMERO { get; set; }
        public string NOMBRE_CALLE { get; set; }
        public string PLANTA_UBICACION { get; set; }
        public decimal ID_CONDOMINIO { get; set; }
        public string NOMBRE { get; set; }
        public string DIRECCION { get; set; }
        public Nullable<decimal> NUMERO_DIRECCION { get; set; }
        public Nullable<decimal> TELEFONO { get; set; }
        public string NOMBRE_COMUNA { get; set; }
        public string NOMBRE_REGION { get; set; }

    }
}
