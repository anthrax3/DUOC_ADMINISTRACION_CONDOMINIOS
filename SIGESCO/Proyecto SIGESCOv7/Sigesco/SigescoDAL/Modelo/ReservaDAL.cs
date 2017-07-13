using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SigescoDAL.Vistas;

namespace SigescoDAL.Modelo
{
    public class ReservaDAL
    {
        public List<RESERVA> GetReservas()
        {
            try
            {
                SigescoEntities bd = new SigescoEntities();
                var listaReservas = from a in bd.RESERVA select a;
                return listaReservas.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public List<string> ObtenerVistaReservasPorVivienda(int vivienda)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.RESERVA
                                 join b in context.ESPACIOS_COMUNES on a.ID_ESPACIO equals b.ID_ESPACIO
                                 join c in context.VIVIENDA on a.ID_VIVIENDA equals c.ID_VIVIENDA
                                 where a.ID_VIVIENDA == vivienda
                                 select new VistaReservasPorVivienda
                                 {
                                     NOMBRE_CALLE = c.NOMBRE_CALLE,
                                     NUMERO = c.NUMERO,
                                     NOMBRE_ESPACIO = b.NOMBRE_ESPACIO,
                                     FECHA_RESERVADA = a.FECHA_RESERVADA,
                                     ESTADO_RESERVA = a.ESTADO_RESERVA
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaReservasPorVivienda> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaReservasPorVivienda obj = new VistaReservasPorVivienda();
                        obj = _lista[i];
                        string fecha = Convert.ToDateTime(obj.FECHA_RESERVADA).ToString("dd/MM/yyyy");
                        string fila = obj.NOMBRE_CALLE + ";" + obj.NUMERO + ";" + obj.NOMBRE_ESPACIO + ";" + fecha + ";" + obj.ESTADO_RESERVA;
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

        public List<string> ObtenerVistaReservasPorEspacio(int espacio)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.RESERVA
                                 join b in context.ESPACIOS_COMUNES on a.ID_ESPACIO equals b.ID_ESPACIO
                                 join c in context.VIVIENDA on a.ID_VIVIENDA equals c.ID_VIVIENDA
                                 join d in context.RESIDENTE on c.ID_VIVIENDA equals d.ID_VIVIENDA
                                 join e in context.PERSONA on d.RUT equals e.RUT
                                 where a.ID_ESPACIO == espacio
                                 select new VistaReservaEspacio
                                 {
                                     PRIMER_NOMBRE = e.PRIMER_NOMBRE,
                                     APELLIDO_PATERNO = e.APELLIDO_PATERNO,
                                     NUMERO = c.NUMERO,
                                     NOMBRE_CALLE = c.NOMBRE_CALLE,
                                     NOMBRE_ESPACIO = b.NOMBRE_ESPACIO,
                                     FECHA_RESERVADA = a.FECHA_RESERVADA,
                                     ESTADO_RESERVA = a.ESTADO_RESERVA
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaReservaEspacio> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaReservaEspacio obj = new VistaReservaEspacio();
                        obj = _lista[i];
                        string fecha = Convert.ToDateTime(obj.FECHA_RESERVADA).ToString("dd/MM/yyyy");
                        string fila = obj.PRIMER_NOMBRE + ";" + obj.APELLIDO_PATERNO + ";" + obj.NUMERO + ";" + obj.NOMBRE_CALLE + ";" + obj.NOMBRE_ESPACIO+";"+fecha+";"+obj.ESTADO_RESERVA;
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

        public List<string> ObtenerVistaReservasPorEspacioSolicitado(int espacio)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.RESERVA
                                 join b in context.ESPACIOS_COMUNES on a.ID_ESPACIO equals b.ID_ESPACIO
                                 join c in context.VIVIENDA on a.ID_VIVIENDA equals c.ID_VIVIENDA
                                 join d in context.RESIDENTE on c.ID_VIVIENDA equals d.ID_VIVIENDA
                                 join e in context.PERSONA on d.RUT equals e.RUT
                                 where a.ID_ESPACIO == espacio &&
                                 a.ESTADO_RESERVA == "SOLICITADO"
                                 select new VistaReservaEspacio
                                 {
                                     PRIMER_NOMBRE = e.PRIMER_NOMBRE,
                                     APELLIDO_PATERNO = e.APELLIDO_PATERNO,
                                     NUMERO = c.NUMERO,
                                     NOMBRE_CALLE = c.NOMBRE_CALLE,
                                     NOMBRE_ESPACIO = b.NOMBRE_ESPACIO,
                                     FECHA_RESERVADA = a.FECHA_RESERVADA,
                                     ESTADO_RESERVA = a.ESTADO_RESERVA,
                                     ID_RESERVA = a.ID_RESERVA
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaReservaEspacio> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaReservaEspacio obj = new VistaReservaEspacio();
                        obj = _lista[i];
                        string fecha = Convert.ToDateTime(obj.FECHA_RESERVADA).ToString("dd/MM/yyyy");
                        string fila = obj.PRIMER_NOMBRE + ";" + obj.APELLIDO_PATERNO + ";" + obj.NUMERO + ";" + obj.NOMBRE_CALLE +
                            ";" + obj.NOMBRE_ESPACIO + ";" + fecha + ";" + obj.ESTADO_RESERVA+";"+obj.ID_RESERVA;
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

        public List<string> ObtenerVistaReservasPorViviendaSolicitado(int vivienda,int espacio)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.RESERVA
                                 join b in context.ESPACIOS_COMUNES on a.ID_ESPACIO equals b.ID_ESPACIO
                                 join c in context.VIVIENDA on a.ID_VIVIENDA equals c.ID_VIVIENDA
                                 join d in context.RESIDENTE on c.ID_VIVIENDA equals d.ID_VIVIENDA
                                 join e in context.PERSONA on d.RUT equals e.RUT
                                 where a.ID_ESPACIO == espacio &&
                                 a.ID_VIVIENDA == vivienda &&
                                 a.ESTADO_RESERVA == "SOLICITADO"
                                 select new VistaReservaEspacio
                                 {
                                     PRIMER_NOMBRE = e.PRIMER_NOMBRE,
                                     APELLIDO_PATERNO = e.APELLIDO_PATERNO,
                                     NUMERO = c.NUMERO,
                                     NOMBRE_CALLE = c.NOMBRE_CALLE,
                                     NOMBRE_ESPACIO = b.NOMBRE_ESPACIO,
                                     FECHA_RESERVADA = a.FECHA_RESERVADA,
                                     ESTADO_RESERVA = a.ESTADO_RESERVA,
                                     ID_RESERVA = a.ID_RESERVA
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaReservaEspacio> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaReservaEspacio obj = new VistaReservaEspacio();
                        obj = _lista[i];
                        string fecha = Convert.ToDateTime(obj.FECHA_RESERVADA).ToString("dd/MM/yyyy");
                        string fila = obj.PRIMER_NOMBRE + ";" + obj.APELLIDO_PATERNO + ";" + obj.NUMERO + ";" + obj.NOMBRE_CALLE +
                            ";" + obj.NOMBRE_ESPACIO + ";" + fecha + ";" + obj.ESTADO_RESERVA + ";" + obj.ID_RESERVA;
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

        public bool AgregarNuevaReserva(RESERVA nuevo)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var existeReserva = (from obj in context.RESERVA
                                         where obj.ID_ESPACIO == obj.ID_ESPACIO && 
                                         obj.FECHA_RESERVADA == nuevo.FECHA_RESERVADA
                                         && obj.ESTADO_RESERVA != "RECHAZADO"
                                         select obj).FirstOrDefault();
                    if (existeReserva == null)
                    {
                        var ultimo = (from obj in context.RESERVA
                                      orderby obj.ID_RESERVA descending
                                      select obj.ID_RESERVA).FirstOrDefault();
                        nuevo.ID_RESERVA = ultimo + 1;
                        context.RESERVA.Add(nuevo);
                        context.SaveChanges();
                        return true;
                    }else
                    { return false; }
                }
                                    
            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool AprobarReserva(RESERVA nuevo)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var existeReserva = (from obj in context.RESERVA
                                         where obj.ID_RESERVA == nuevo.ID_RESERVA
                                         select obj).FirstOrDefault();
                    RESERVA actual = existeReserva;
                    actual.ESTADO_RESERVA = nuevo.ESTADO_RESERVA;
                    context.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }//fin clase
}
