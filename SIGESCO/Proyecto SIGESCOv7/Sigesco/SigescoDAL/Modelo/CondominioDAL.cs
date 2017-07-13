using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SigescoDAL.Vistas;

namespace SigescoDAL.Modelo
{
    public class CondominioDAL
    {

        public List<string> GetCondominioPorUsuario(string usuario)
        {
            try
            {
                UsuarioDAL usuarioDal = new UsuarioDAL();
                int _usu = int.Parse(usuario);
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.USUARIO_X_CONDOMINIO
                                 join b in context.CONDOMINIO on a.ID_CONDOMINIO equals b.ID_CONDOMINIO
                                 join c in context.COMUNA on b.ID_COMUNA equals c.ID_COMUNA
                                 join d in context.REGION on c.ID_REGION equals d.ID_REGION
                                 where a.ID_USUARIO == _usu
                                 select new VistaCondominiosPorUsuario
                                 {
                                     ID_CONDOMINIO = a.ID_CONDOMINIO,
                                     NOMBRE = b.NOMBRE,
                                     DIRECCION = b.DIRECCION,
                                     NUMERO_DIRECCION = b.NUMERO_DIRECCION,
                                     TELEFONO = b.TELEFONO,
                                     NOMBRE_COMUNA = c.NOMBRE_COMUNA,
                                     NOMBRE_REGION = d.NOMBRE_REGION
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaCondominiosPorUsuario> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        var obj = _lista[i];
                        string fila = obj.ID_CONDOMINIO+";"+obj.NOMBRE+";"+obj.DIRECCION+";"+obj.NUMERO_DIRECCION+";"+obj.NOMBRE_COMUNA+";"+obj.NOMBRE_REGION;
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
        public List<string> GetViviendasPorUsuario(string usuario)
        {
            try
            {
                UsuarioDAL usuarioDal = new UsuarioDAL();
                int rut = int.Parse(usuarioDal.RetronarRutUsuario(usuario));
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.RESIDENTE
                                 join b in context.VIVIENDA on a.ID_VIVIENDA equals b.ID_VIVIENDA
                                 join c in context.CONDOMINIO on b.ID_CONDOMINIO equals c.ID_CONDOMINIO
                                 join d in context.COMUNA on c.ID_COMUNA equals d.ID_COMUNA
                                 join e in context.REGION on d.ID_REGION equals e.ID_REGION                                
                                 where a.RUT == rut
                                 select new VistaViviendasPorUsuario
                                 {
                                     ID_VIVIENDA = b.ID_VIVIENDA,
                                     NUMERO = b.NUMERO,
                                     NOMBRE_CALLE = b.NOMBRE_CALLE,
                                     PLANTA_UBICACION = b.PLANTA_UBICACION,
                                     ID_CONDOMINIO = c.ID_CONDOMINIO,
                                     NOMBRE = c.NOMBRE,
                                     DIRECCION = c.DIRECCION,
                                     NUMERO_DIRECCION = c.NUMERO_DIRECCION,
                                     TELEFONO = c.TELEFONO,
                                     NOMBRE_COMUNA = d.NOMBRE_COMUNA,
                                     NOMBRE_REGION = e.NOMBRE_REGION
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaViviendasPorUsuario> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaViviendasPorUsuario obj = new VistaViviendasPorUsuario();
                        obj = _lista[i];
                        string fila = obj.ID_VIVIENDA+";"+obj.NUMERO+";"+obj.NOMBRE_CALLE+";"+obj.PLANTA_UBICACION+
                            ";" + obj.ID_CONDOMINIO + ";" + obj.NOMBRE + ";" + obj.DIRECCION + ";" + obj.NUMERO_DIRECCION +
                            ";" + obj.TELEFONO + ";" + obj.NOMBRE_COMUNA + ";" + obj.NOMBRE_REGION;
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

        public List<string> GetRegiones()
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.REGION
                                 select a).ToList();

                    List<string> lista = new List<string>();
                    List<REGION> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        REGION obj = new REGION();
                        obj = _lista[i];
                        string fila = obj.ID_REGION + ";" + obj.NOMBRE_REGION;
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

        public List<string> GetCondominios()
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.CONDOMINIO
                                 select a).ToList();

                    List<string> lista = new List<string>();
                    List<CONDOMINIO> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        CONDOMINIO obj = new CONDOMINIO();
                        obj = _lista[i];
                        string fila = obj.NOMBRE + ";" + obj.DIRECCION + ' ' + obj.NUMERO_DIRECCION + ";" + obj.TELEFONO+";"+obj.ID_CONDOMINIO ;
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

       
        public List<string> GetViviendas()
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.CONDOMINIO
                                 join b in context.VIVIENDA on a.ID_CONDOMINIO equals b.ID_CONDOMINIO
                                 select new VistaInfoViviendaCondominio
                                 {
                                     NOMBRE_CALLE_VIV = b.NOMBRE_CALLE,
                                     NOMBRE_COND = a.NOMBRE,
                                     NUMERO_VIV = b.NUMERO,
                                     PLANTA_UBICACION_VIV = b.PLANTA_UBICACION,
                                     ID_VIVIENDA = b.ID_VIVIENDA
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaInfoViviendaCondominio> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaInfoViviendaCondominio obj = new VistaInfoViviendaCondominio();
                        obj = _lista[i];
                        string fila = obj.NOMBRE_COND + ";" + obj.NOMBRE_CALLE_VIV + ";" + obj.NUMERO_VIV + ";" + obj.PLANTA_UBICACION_VIV;
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

        public List<string> GetEspacios()
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.CONDOMINIO
                                 join b in context.ESPACIOS_COMUNES on a.ID_CONDOMINIO equals b.ID_CONDOMINIO
                                 orderby a.ID_CONDOMINIO ascending
                                 orderby b.ID_ESPACIO ascending
                                 select new VistaEspacios
                                 {
                                     NOMBRE = a.NOMBRE,
                                     NOMBRE_ESPACIO = b.NOMBRE_ESPACIO,
                                     DESCRIPCION_ESPACIO = b.DESCRIPCION_ESPACIO
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaEspacios> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaEspacios obj = new VistaEspacios();
                        obj = _lista[i];
                        string fila = obj.NOMBRE + ";" + obj.NOMBRE_ESPACIO + ";" + obj.DESCRIPCION_ESPACIO;
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

        public bool InsertarCondominio(CONDOMINIO cond)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.CONDOMINIO
                                 orderby a.ID_CONDOMINIO descending
                                 select a.ID_CONDOMINIO).FirstOrDefault();
                    cond.ID_CONDOMINIO = query + 1;
                    context.CONDOMINIO.Add(cond);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool InsertarVivienda(VIVIENDA cond)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.VIVIENDA
                                 orderby a.ID_VIVIENDA descending
                                 select a.ID_VIVIENDA).FirstOrDefault();
                    cond.ID_VIVIENDA = query + 1;
                    context.VIVIENDA.Add(cond);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool InsertarEspacio(ESPACIOS_COMUNES cond)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.ESPACIOS_COMUNES
                                 orderby a.ID_ESPACIO descending
                                 select a.ID_ESPACIO).FirstOrDefault();
                    cond.ID_ESPACIO = query + 1;
                    context.ESPACIOS_COMUNES.Add(cond);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<string> GetComunas(int idRegion)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.COMUNA
                                 where a.ID_REGION==idRegion
                                 select a).ToList();

                    List<string> lista = new List<string>();
                    List<COMUNA> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        COMUNA obj = new COMUNA();
                        obj = _lista[i];
                        string fila = obj.ID_COMUNA + ";" + obj.NOMBRE_COMUNA;
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

        public List<string> GetViviendasPorCondominio(int condominio)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.CONDOMINIO
                                 join b in context.VIVIENDA on a.ID_CONDOMINIO equals b.ID_CONDOMINIO
                                 where a.ID_CONDOMINIO == condominio
                                 select new VistaInfoViviendaCondominio
                                 {
                                     NOMBRE_CALLE_VIV = b.NOMBRE_CALLE,
                                     NOMBRE_COND = a.NOMBRE,
                                     NUMERO_VIV = b.NUMERO,
                                     PLANTA_UBICACION_VIV = b.PLANTA_UBICACION,
                                     ID_VIVIENDA = b.ID_VIVIENDA
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaInfoViviendaCondominio> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaInfoViviendaCondominio obj = new VistaInfoViviendaCondominio();
                        obj = _lista[i];
                        string fila =  obj.ID_VIVIENDA + ";" + obj.NOMBRE_CALLE_VIV + ";" + obj.NUMERO_VIV + ";" + obj.PLANTA_UBICACION_VIV ;
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

        public List<string> GetViviendasPorUsuarioPorCondominio(string usuario, int condominio)
        {
            try
            {
                UsuarioDAL usuarioDal = new UsuarioDAL();
                int rut = int.Parse(usuarioDal.RetronarRutUsuario(usuario));
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.RESIDENTE
                                 join b in context.VIVIENDA on a.ID_VIVIENDA equals b.ID_VIVIENDA
                                 join c in context.CONDOMINIO on b.ID_CONDOMINIO equals c.ID_CONDOMINIO
                                 join d in context.COMUNA on c.ID_COMUNA equals d.ID_COMUNA
                                 join e in context.REGION on d.ID_REGION equals e.ID_REGION
                                 where a.RUT == rut && c.ID_CONDOMINIO==condominio
                                 select new VistaViviendasPorUsuario
                                 {
                                     ID_VIVIENDA = b.ID_VIVIENDA,
                                     NUMERO = b.NUMERO,
                                     NOMBRE_CALLE = b.NOMBRE_CALLE,
                                     PLANTA_UBICACION = b.PLANTA_UBICACION,
                                     ID_CONDOMINIO = c.ID_CONDOMINIO,
                                     NOMBRE = c.NOMBRE,
                                     DIRECCION = c.DIRECCION,
                                     NUMERO_DIRECCION = c.NUMERO_DIRECCION,
                                     TELEFONO = c.TELEFONO,
                                     NOMBRE_COMUNA = d.NOMBRE_COMUNA,
                                     NOMBRE_REGION = e.NOMBRE_REGION
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaViviendasPorUsuario> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaViviendasPorUsuario obj = new VistaViviendasPorUsuario();
                        obj = _lista[i];
                        string fila = obj.ID_VIVIENDA + ";" + obj.NUMERO + ";" + obj.NOMBRE_CALLE + ";" + obj.PLANTA_UBICACION +
                            ";" + obj.ID_CONDOMINIO + ";" + obj.NOMBRE + ";" + obj.DIRECCION + ";" + obj.NUMERO_DIRECCION +
                            ";" + obj.TELEFONO + ";" + obj.NOMBRE_COMUNA + ";" + obj.NOMBRE_REGION;
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
        public List<string> RetronarVistaInfoVivienda(string usuario)
        {
            try
            {
                UsuarioDAL usuarioDal = new UsuarioDAL();
                int rut=int.Parse(usuarioDal.RetronarRutUsuario(usuario));
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.RESIDENTE
                                           join b in context.VIVIENDA on a.ID_VIVIENDA equals b.ID_VIVIENDA
                                           join c in context.CONDOMINIO on b.ID_CONDOMINIO equals c.ID_CONDOMINIO
                                           where a.RUT == rut
                                           select new VistaInfoViviendaCondominio
                                           {
                                               NOMBRE_CALLE_VIV = b.NOMBRE_CALLE,
                                               NOMBRE_COND = c.NOMBRE,
                                               NUMERO_VIV = b.NUMERO,
                                               PLANTA_UBICACION_VIV = b.PLANTA_UBICACION,
                                               ID_VIVIENDA = b.ID_VIVIENDA
                                           }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaInfoViviendaCondominio> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaInfoViviendaCondominio obj = new VistaInfoViviendaCondominio();
                        obj = _lista[i];
                        string fila = obj.NOMBRE_COND + ";" + obj.NOMBRE_CALLE_VIV + ";" + obj.NUMERO_VIV + ";" + obj.PLANTA_UBICACION_VIV + ";" +obj.ID_VIVIENDA;
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

        public List<string> RetronarVistaInfoCondominios(int usuario)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.USUARIO_X_CONDOMINIO
                                 join b in context.CONDOMINIO on a.ID_CONDOMINIO equals b.ID_CONDOMINIO
                                 join c in context.COMUNA on b.ID_COMUNA equals c.ID_COMUNA
                                 join e in context.REGION on c.ID_REGION equals e.ID_REGION
                                 where a.ID_USUARIO == usuario
                                 select new VistaCondominiosPorUsuario
                                 {
                                     NOMBRE = b.NOMBRE,
                                     DIRECCION = b.DIRECCION,
                                     NUMERO_DIRECCION = b.NUMERO_DIRECCION,
                                     NOMBRE_COMUNA = c.NOMBRE_COMUNA,
                                     NOMBRE_REGION = e.NOMBRE_REGION
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaCondominiosPorUsuario> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaCondominiosPorUsuario obj = new VistaCondominiosPorUsuario();
                        obj = _lista[i];
                        string fila = obj.NOMBRE + ";" + obj.DIRECCION + ";" + obj.NUMERO_DIRECCION + ";" + obj.NOMBRE_COMUNA+";"+obj.NOMBRE_REGION;
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

    }//fin Clase
}
