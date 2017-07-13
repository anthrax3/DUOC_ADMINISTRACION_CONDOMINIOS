using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigescoDAL.Modelo
{
    public class PersonaDAL
    {
        public List<string> GetPersonas()
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.PERSONA
                                 orderby a.PRIMER_NOMBRE ascending
                                 orderby a.APELLIDO_PATERNO ascending
                                 select a).ToList();

                    List<string> lista = new List<string>();
                    List<PERSONA> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        var obj = _lista[i];
                        int rut = int.Parse(obj.RUT.ToString());
                        string _rut = obj.RUT.ToString();
                        string dv = "";
                        int suma = 0;
                        int multiplicador = 1;
                        while (rut != 0)
                        {
                            multiplicador++;
                            if (multiplicador == 8)
                                multiplicador = 2;
                            suma += (rut % 10) * multiplicador;
                            rut = rut / 10;
                        }
                        suma = 11 - (suma % 11);
                        if (suma == 11)
                            dv = "0";
                        else if (suma == 10)
                            dv = "K";
                        else
                            dv = suma.ToString();
                        string fila = obj.RUT+";"+ _rut + "-" + dv + ";" + obj.PRIMER_NOMBRE + ";" + obj.APELLIDO_PATERNO;
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
