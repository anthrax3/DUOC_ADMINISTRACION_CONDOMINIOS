﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SigescoDAL.Vistas
{
    public class VistaReservaEspacio
    {
        public string PRIMER_NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string NUMERO { get; set; }
        public string NOMBRE_CALLE { get; set; }
        public string NOMBRE_ESPACIO { get; set; }
        public Nullable<System.DateTime> FECHA_RESERVADA { get; set; }
        public string ESTADO_RESERVA { get; set; }
        public decimal ID_RESERVA { get; set; }
    }
}
