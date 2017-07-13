using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SigescoDAL.Vistas;

namespace SigescoDAL
{
    public class EspaciosDAL
    {
        public List<ESPACIOS_COMUNES> GetEspacios()
        {
            try
            {
                SigescoEntities bd = new SigescoEntities();
                var listaEspacios = from a in bd.ESPACIOS_COMUNES select a;
                return listaEspacios.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<ESPACIOS_COMUNES> GetEspaciosXcondominio(int cond)
        {
            try
            {
                SigescoEntities bd = new SigescoEntities();
                var listaEspacios = from a in bd.ESPACIOS_COMUNES select a;
                return listaEspacios.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
