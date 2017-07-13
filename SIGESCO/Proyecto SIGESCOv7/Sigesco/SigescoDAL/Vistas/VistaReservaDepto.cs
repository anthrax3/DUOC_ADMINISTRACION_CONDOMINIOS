using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SigescoDAL.Vistas
{
    public class VistaReservaDepto
    {
       public string  _DPT_NUMERO { get; set; }
        public string _USU_NOMBRE  { get; set; }
         public string _USU_APELLIDO  { get; set; }
        public decimal _EC_ID_ESPACIO  { get; set; }
        public Nullable<System.DateTime> _RS_FECHA  { get; set; }
    }
}
