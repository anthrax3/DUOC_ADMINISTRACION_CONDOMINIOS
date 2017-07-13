using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SigescoDAL.Modelo
{
    public class AreasComunesDAL
    {
        public List<string> GetAreasPorCondominio(int condominio)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.ESPACIOS_COMUNES
                                where a.ID_CONDOMINIO== condominio
                                select a).ToList();

                    List<string> lista = new List<string>();
                    List<ESPACIOS_COMUNES> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        var obj = _lista[i];
                        string fila = obj.ID_ESPACIO + ";" + obj.NOMBRE_ESPACIO + ";" + obj.DESCRIPCION_ESPACIO;
                        lista.Add(fila);
                    }

                    return lista;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
