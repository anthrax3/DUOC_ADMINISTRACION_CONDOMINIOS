//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SigescoDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class GASTO
    {
        public GASTO()
        {
            this.PAGOXGASTO = new HashSet<PAGOXGASTO>();
        }
    
        public decimal ID_GASTO { get; set; }
        public string NOMBRE_GASTO { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<System.DateTime> FECHA_GASTO { get; set; }
        public Nullable<decimal> ID_VIVIENDA { get; set; }
        public Nullable<decimal> ID_TIPO_GASTO { get; set; }
        public Nullable<decimal> MONTO_GASTO { get; set; }
        public string ESTADO { get; set; }
        public string OBSERVACION { get; set; }
    
        public virtual TIPO_GASTO TIPO_GASTO { get; set; }
        public virtual VIVIENDA VIVIENDA { get; set; }
        public virtual ICollection<PAGOXGASTO> PAGOXGASTO { get; set; }
    }
}