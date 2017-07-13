using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SigescoDAL.Vistas;

namespace SigescoDAL.Modelo
{
    public class GastosDAL
    {

        public bool InsertarGastoMasivo(List<GASTO> lista)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    int x = lista.Count();
                    for (int i = 1; i < 5; i++)
                    {
                        context.GASTO.Add(lista[i]);
                        context.SaveChanges();                        
                    }
                    return true;
                    
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int ultimo()
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.GASTO
                                 orderby a.ID_GASTO descending
                                 select a.ID_GASTO).FirstOrDefault();
                    return int.Parse(query.ToString());
                }
            }catch(Exception e)
            {
                throw  e;
            }
        }

        public bool ActualizarObervacionPorGasto(int gasto,string texto)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.GASTO
                                 where a.ID_GASTO == gasto
                                 select a).FirstOrDefault();

                    GASTO objeto = query;
                    if(texto=="")
                    {
                        objeto.OBSERVACION = null;
                        context.SaveChanges();
                        return true;
                    }else
                    {
                        objeto.OBSERVACION = texto;
                        context.SaveChanges();
                        return true;
                    }

                    
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string getGastoPorID(int gasto)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.GASTO
                                 where a.ID_GASTO == gasto
                                 select a).FirstOrDefault();
                    GASTO obj = query;
                    string retorno = "";
                    string fecha = Convert.ToDateTime(obj.FECHA_GASTO).ToString("dd/MM/yyyy");
                    retorno = obj.ID_GASTO+"{"+obj.NOMBRE_GASTO + "{"+obj.DESCRIPCION+ "{"+obj.ID_TIPO_GASTO + "{"+obj.MONTO_GASTO;

                    return retorno;

                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public bool updateGastoPorID(GASTO gasto)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.GASTO
                                 where a.ID_GASTO == gasto.ID_GASTO
                                 select a).FirstOrDefault();

                    query.ID_TIPO_GASTO = gasto.ID_TIPO_GASTO;
                    query.MONTO_GASTO = gasto.ID_VIVIENDA;
                    query.DESCRIPCION = gasto.DESCRIPCION;
                    query.NOMBRE_GASTO = gasto.NOMBRE_GASTO;
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IngresarNuevaMulta(GASTO multa)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.GASTO
                                 orderby a.ID_GASTO descending
                                 select a.ID_GASTO).FirstOrDefault();

                    multa.ID_GASTO = query + 1;
                    context.GASTO.Add(multa);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string GetObsPorGasto(int idGasto)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.GASTO
                                 where a.ID_GASTO==idGasto
                                 select a.OBSERVACION).FirstOrDefault();

                    string lista = query;                 

                    return lista;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<string> GetGastoNoPagadoPorId(int gasto)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.GASTO
                                 where a.ID_GASTO == gasto
                                 && a.ESTADO == "NO PAGADO"
                                 orderby a.FECHA_GASTO ascending
                                 select a).ToList();

                    List<string> lista = new List<string>();
                    List<GASTO> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        GASTO obj = new GASTO();
                        obj = _lista[i];
                        string fecha = Convert.ToDateTime(obj.FECHA_GASTO).ToString("dd/MM/yyyy");
                        string fila = obj.ID_GASTO + ";" + obj.NOMBRE_GASTO + ";" + fecha + ";" + obj.MONTO_GASTO;
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

        public List<string> GetGastosSinObsPorVivienda(int vivienda, DateTime desde, DateTime hasta)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.GASTO
                                 where a.ID_VIVIENDA == vivienda &&
                                 a.FECHA_GASTO >= desde &&
                                 a.FECHA_GASTO <= hasta &&
                                 a.OBSERVACION == null
                                 orderby a.FECHA_GASTO ascending
                                 select a).ToList();

                    List<string> lista = new List<string>();
                    List<GASTO> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        GASTO obj = new GASTO();
                        obj = _lista[i];
                        string fila = obj.ID_GASTO + ";" + obj.NOMBRE_GASTO + ";" + obj.MONTO_GASTO;
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

        public List<string> GetGastosConObsPorVivienda(int vivienda, DateTime desde, DateTime hasta)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.GASTO
                                 where a.ID_VIVIENDA == vivienda &&
                                 a.FECHA_GASTO >= desde &&
                                 a.FECHA_GASTO <= hasta &&
                                 a.OBSERVACION != null
                                 orderby a.FECHA_GASTO ascending
                                 select a).ToList();

                    List<string> lista = new List<string>();
                    List<GASTO> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        GASTO obj = new GASTO();
                        obj = _lista[i];
                        string fila = obj.ID_GASTO + ";" + obj.NOMBRE_GASTO + ";" + obj.MONTO_GASTO;
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
        public List<string> ObtenerVistaMultasPorVivienda(int vivienda)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.GASTO
                                 join b in context.VIVIENDA on a.ID_VIVIENDA equals b.ID_VIVIENDA
                                 where a.ID_VIVIENDA == vivienda &&
                                 a.ID_TIPO_GASTO == 4
                                 orderby a.FECHA_GASTO ascending
                                 select new VistaMultasPorVivienda
                                 {
                                     DESCRIPCION = a.DESCRIPCION,
                                     FECHA_GASTO = a.FECHA_GASTO,
                                     NOMBRE_CALLE = b.NOMBRE_CALLE,
                                     NUMERO = b.NUMERO,
                                     MONTO_GASTO = a.MONTO_GASTO,
                                     ESTADO = a.ESTADO                                     
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaMultasPorVivienda> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaMultasPorVivienda obj = new VistaMultasPorVivienda();
                        obj = _lista[i];
                        string fecha = Convert.ToDateTime(obj.FECHA_GASTO).ToString("dd/MM/yyyy");
                        string fila = obj.DESCRIPCION + ";" + fecha + ";" + obj.NOMBRE_CALLE + ";" + obj.NUMERO + ";" + obj.MONTO_GASTO+";"+obj.ESTADO;
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

        public List<string> ObtenerVistaMultasPagaPorCondominioPorFecha(int condominio, DateTime desde, DateTime hasta)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.GASTO
                                 join b in context.VIVIENDA on a.ID_VIVIENDA equals b.ID_VIVIENDA
                                 join c in context.PAGOXGASTO on a.ID_GASTO equals c.ID_GASTO
                                 join d in context.PAGO on c.ID_PAGO equals d.ID_PAGO
                                 join e in context.TIPO_PAGO on d.ID_TIPO_PAGO equals e.ID_TIPO_PAGO
                                 where b.ID_CONDOMINIO == condominio &&
                                 a.ID_TIPO_GASTO == 4 &&
                                 a.FECHA_GASTO >= desde &&
                                 a.FECHA_GASTO <= hasta &&
                                 a.ESTADO == "PAGADO"                                                              
                                 orderby a.FECHA_GASTO ascending
                                 select new VistaMultasPagaPorCondominioPorFecha
                                 {
                                     FECHA_GASTO = a.FECHA_GASTO,
                                     NOMBRE_CALLE = b.NOMBRE_CALLE,
                                     NUMERO = b.NUMERO,
                                     PLANTA_UBICACION = b.PLANTA_UBICACION,
                                     DESCRIPCION = a.DESCRIPCION,
                                     MONTO_GASTO = a.MONTO_GASTO,
                                     DOCUMENTO = d.DOCUMENTO,
                                     DESCRIPCION_TIPO = e.DESCRIPCION_TIPO,
                                     FECHA = d.FECHA
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaMultasPagaPorCondominioPorFecha> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaMultasPagaPorCondominioPorFecha obj = new VistaMultasPagaPorCondominioPorFecha();
                        obj = _lista[i];
                        string fecha = Convert.ToDateTime(obj.FECHA_GASTO).ToString("dd/MM/yyyy");
                        string fecha2 = Convert.ToDateTime(obj.FECHA).ToString("dd/MM/yyyy");
                        string fila = fecha + "&&" + obj.NOMBRE_CALLE + " #" + obj.NUMERO + " :: " + obj.PLANTA_UBICACION + "&&" + obj.DESCRIPCION +
                            "&&" +obj.MONTO_GASTO+"&&"+obj.DOCUMENTO+"&&"+obj.DESCRIPCION_TIPO+"&&"+fecha2;
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

        public List<string> ObtenerVistaMultasNoPagaPorCondominioPorFecha(int condominio, DateTime desde, DateTime hasta)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.GASTO
                                 join b in context.VIVIENDA on a.ID_VIVIENDA equals b.ID_VIVIENDA
                                 where b.ID_CONDOMINIO == condominio &&
                                 a.ID_TIPO_GASTO == 4 &&
                                 a.FECHA_GASTO >= desde &&
                                 a.FECHA_GASTO <= hasta &&
                                 a.ESTADO == "NO PAGADO"
                                 orderby a.FECHA_GASTO ascending
                                 select new VistaMultasNoPagaPorCondominioPorFecha
                                 {
                                     FECHA_GASTO = a.FECHA_GASTO,
                                     NOMBRE_CALLE = b.NOMBRE_CALLE,
                                     NUMERO = b.NUMERO,
                                     PLANTA_UBICACION = b.PLANTA_UBICACION,
                                     DESCRIPCION = a.DESCRIPCION,
                                     MONTO_GASTO = a.MONTO_GASTO,
                                     OBSERVACION = a.OBSERVACION
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaMultasNoPagaPorCondominioPorFecha> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaMultasNoPagaPorCondominioPorFecha obj = new VistaMultasNoPagaPorCondominioPorFecha();
                        obj = _lista[i];
                        string fecha = Convert.ToDateTime(obj.FECHA_GASTO).ToString("dd/MM/yyyy");
                        string fila = fecha + "&&" + obj.NOMBRE_CALLE + " #" + obj.NUMERO + " :: " + obj.PLANTA_UBICACION + "&&" + obj.DESCRIPCION +
                            "&&" + obj.MONTO_GASTO + "&&" + obj.OBSERVACION;
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

        public List<string> ObtenerVistaGastoPagoPorCondominioPorFecha(int residencia, DateTime desde, DateTime hasta)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.GASTO
                                 join b in context.VIVIENDA on a.ID_VIVIENDA equals b.ID_VIVIENDA
                                 join c in context.PAGOXGASTO on a.ID_GASTO equals c.ID_GASTO
                                 join d in context.PAGO on c.ID_PAGO equals d.ID_PAGO
                                 join e in context.TIPO_PAGO on d.ID_TIPO_PAGO equals e.ID_TIPO_PAGO
                                 where b.ID_VIVIENDA == residencia &&
                                 a.FECHA_GASTO >= desde &&
                                 a.FECHA_GASTO <= hasta &&
                                 a.ESTADO == "PAGADO"
                                 orderby a.FECHA_GASTO ascending
                                 select new VistaMultasPagaPorCondominioPorFecha
                                 {
                                     FECHA_GASTO = a.FECHA_GASTO,
                                     NOMBRE_CALLE = b.NOMBRE_CALLE,
                                     NUMERO = b.NUMERO,
                                     PLANTA_UBICACION = b.PLANTA_UBICACION,
                                     DESCRIPCION = a.NOMBRE_GASTO,
                                     MONTO_GASTO = a.MONTO_GASTO,
                                     DOCUMENTO = d.DOCUMENTO,
                                     DESCRIPCION_TIPO = e.DESCRIPCION_TIPO,
                                     FECHA = d.FECHA
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaMultasPagaPorCondominioPorFecha> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaMultasPagaPorCondominioPorFecha obj = new VistaMultasPagaPorCondominioPorFecha();
                        obj = _lista[i];
                        string fecha = Convert.ToDateTime(obj.FECHA_GASTO).ToString("dd/MM/yyyy");
                        string fecha2 = Convert.ToDateTime(obj.FECHA).ToString("dd/MM/yyyy");
                        string fila = fecha + "&&" + obj.NOMBRE_CALLE + " #" + obj.NUMERO + " :: " + obj.PLANTA_UBICACION + "&&" + obj.DESCRIPCION +
                            "&&" + obj.MONTO_GASTO + "&&" + obj.DOCUMENTO + "&&" + obj.DESCRIPCION_TIPO + "&&" + fecha2;
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

        public List<string> ObtenerVistaGastoNoPagoPorCondominioPorFecha(int residencia, DateTime desde, DateTime hasta)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.GASTO
                                 join b in context.VIVIENDA on a.ID_VIVIENDA equals b.ID_VIVIENDA
                                 where b.ID_VIVIENDA == residencia &&
                                 a.FECHA_GASTO >= desde &&
                                 a.FECHA_GASTO <= hasta &&
                                 a.ESTADO == "NO PAGADO"
                                 orderby a.FECHA_GASTO ascending
                                 select new VistaMultasNoPagaPorCondominioPorFecha
                                 {
                                     FECHA_GASTO = a.FECHA_GASTO,
                                     NOMBRE_CALLE = b.NOMBRE_CALLE,
                                     NUMERO = b.NUMERO,
                                     PLANTA_UBICACION = b.PLANTA_UBICACION,
                                     DESCRIPCION = a.NOMBRE_GASTO,
                                     MONTO_GASTO = a.MONTO_GASTO,
                                     OBSERVACION = a.OBSERVACION
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaMultasNoPagaPorCondominioPorFecha> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaMultasNoPagaPorCondominioPorFecha obj = new VistaMultasNoPagaPorCondominioPorFecha();
                        obj = _lista[i];
                        string fecha = Convert.ToDateTime(obj.FECHA_GASTO).ToString("dd/MM/yyyy");
                        string fila = fecha + "&&" + obj.NOMBRE_CALLE + " #" + obj.NUMERO + " :: " + obj.PLANTA_UBICACION + "&&" + obj.DESCRIPCION +
                            "&&" + obj.MONTO_GASTO + "&&" + obj.OBSERVACION;
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
        public List<string> ObtenerVistaGastosPorVivienda(int vivienda,DateTime desde, DateTime hasta)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.GASTO
                                 join b in context.VIVIENDA on a.ID_VIVIENDA equals b.ID_VIVIENDA
                                 where a.ID_VIVIENDA == vivienda &&
                                 a.FECHA_GASTO >= desde &&
                                 a.FECHA_GASTO <= hasta
                                 orderby a.FECHA_GASTO ascending
                                 select new VistaGastosPorVivienda
                                 {
                                     NOMBRE_GASTO = a.NOMBRE_GASTO,
                                     FECHA_GASTO = a.FECHA_GASTO,
                                     MONTO_GASTO = a.MONTO_GASTO,
                                     ESTADO = a.ESTADO,
                                     OBSERVACION = a.OBSERVACION,
                                    ID_GASTO = a.ID_GASTO

                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaGastosPorVivienda> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaGastosPorVivienda obj = new VistaGastosPorVivienda();
                        obj = _lista[i];
                        string fecha = Convert.ToDateTime(obj.FECHA_GASTO).ToString("dd/MM/yyyy");
                        string fila = obj.NOMBRE_GASTO + ";" + fecha + ";" + obj.MONTO_GASTO + ";" + obj.ESTADO + ";" + obj.OBSERVACION + ";" + obj.ID_GASTO;
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

        public List<string> ObtenerGastosPorPagarPorVivienda(int vivienda, DateTime desde, DateTime hasta)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.GASTO
                                 where a.ID_VIVIENDA == vivienda &&
                                 a.FECHA_GASTO >= desde &&
                                 a.FECHA_GASTO <= hasta &&
                                 a.ESTADO == "NO PAGADO"
                                 orderby a.FECHA_GASTO ascending
                                 select a).ToList();

                    List<string> lista = new List<string>();
                    List<GASTO> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        GASTO obj = new GASTO();
                        obj = _lista[i];
                        string fecha = Convert.ToDateTime(obj.FECHA_GASTO).ToString("dd/MM/yyyy");
                        string fila = obj.NOMBRE_GASTO + ";" + obj.DESCRIPCION + ";" + fecha + ";" + obj.MONTO_GASTO + ";" + obj.OBSERVACION + ";" + obj.ID_GASTO;
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

        public List<string> ObtenerVistaMorosidadPorVivienda(int vivienda)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.GASTO
                                 join b in context.VIVIENDA on a.ID_VIVIENDA equals b.ID_VIVIENDA
                                 where a.ID_VIVIENDA == vivienda &&
                                 a.ESTADO == "NO PAGADO" &&
                                 a.FECHA_GASTO <= DateTime.Now
                                 orderby a.FECHA_GASTO ascending
                                 select new VistaMorosidadPorVivienda
                                 {
                                     NOMBRE_GASTO = a.NOMBRE_GASTO,
                                     FECHA_GASTO = a.FECHA_GASTO,
                                     DESCRIPCION = a.DESCRIPCION,
                                     MONTO_GASTO = a.MONTO_GASTO
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaMorosidadPorVivienda> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaMorosidadPorVivienda obj = new VistaMorosidadPorVivienda();
                        obj = _lista[i];
                        string fecha = Convert.ToDateTime(obj.FECHA_GASTO).ToString("dd/MM/yyyy");
                        string fila = obj.NOMBRE_GASTO + ";" + fecha + ";" +obj.DESCRIPCION+";"+ obj.MONTO_GASTO;
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

        public List<string> ObtenerVistaMorosidadPorCondominio(int condominio)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.GASTO
                                 join b in context.VIVIENDA on a.ID_VIVIENDA equals b.ID_VIVIENDA
                                 join c in context.CONDOMINIO on b.ID_CONDOMINIO equals c.ID_CONDOMINIO
                                 where c.ID_CONDOMINIO == condominio &&
                                 a.ESTADO == "NO PAGADO" &&
                                 a.FECHA_GASTO <= DateTime.Now
                                 orderby a.FECHA_GASTO ascending
                                 select new VistaMorosidadPorCondominio
                                 {
                                     NOMBRE = c.NOMBRE,
                                     NOMBRE_CALLE = b.NOMBRE_CALLE,
                                     NUMERO = b.NUMERO,
                                     PLANTA_UBICACION = b.PLANTA_UBICACION,
                                     ID_GASTO = a.ID_GASTO,
                                     NOMBRE_GASTO = a.NOMBRE_GASTO,
                                     FECHA_GASTO = a.FECHA_GASTO,
                                     MONTO_GASTO = a.MONTO_GASTO
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaMorosidadPorCondominio> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaMorosidadPorCondominio obj = new VistaMorosidadPorCondominio();
                        obj = _lista[i];
                        string fecha = Convert.ToDateTime(obj.FECHA_GASTO).ToString("dd/MM/yyyy");
                        string fila = obj.NOMBRE+";"+obj.NOMBRE_CALLE+" #"+obj.NUMERO+"- P: "+obj.PLANTA_UBICACION+";"+
                            obj.ID_GASTO+";"+obj.NOMBRE_GASTO+";"+fecha+";"+obj.MONTO_GASTO;
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

    }//fin clase    
}
