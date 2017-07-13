using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SigescoDAL.Vistas;

namespace SigescoDAL.Modelo
{
    public class AnunciosDAL
    {
        public List<ANUNCIOS> GetAnuncios()
        {
            try
            {
                SigescoEntities bd = new SigescoEntities();
                var listaAnuncios = from a in bd.ANUNCIOS orderby a.FECHA_ANUNCIO descending select a;
                return listaAnuncios.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string ultimoAnuncio()
        {
            try
            {
                SigescoEntities bd = new SigescoEntities();
                var q_anuncio = from a in bd.ANUNCIOS orderby a.FECHA_ANUNCIO descending select a;
                ANUNCIOS anun = q_anuncio.First();
                string ultimo = anun.FECHA_ANUNCIO+"|"+anun.TITULO+ "|" + anun.CUERPO+ "|" + anun.REMITENTE;
                return ultimo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CrearAnuncio(ANUNCIOS anun)
        {
            try
            {
                SigescoEntities bd = new SigescoEntities();
                using (bd)
                {
                    var query = (from a in bd.ANUNCIOS
                                 orderby a.ID_ANUNCIO descending
                                 select a.ID_ANUNCIO).FirstOrDefault();
                    anun.ID_ANUNCIO = query+1;
                    bd.ANUNCIOS.Add(anun);
                    bd.SaveChanges();
                    return true;
                }                    
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<string> Obtener20UltimosAuncios(int condominio)
        {
            try
            {
                SigescoEntities bd = new SigescoEntities();
                var listaAnuncios = (from a in bd.ANUNCIOS
                                     where a.ID_CONDOMINIO == condominio
                                     orderby a.FECHA_ANUNCIO descending
                                     select a).Take(20).ToList();

                List<string> lista = new List<string>();
                List<ANUNCIOS> _lista = listaAnuncios;
                int x = _lista.Count();
                for (int i = 0; i<x; i++)
                {
                    ANUNCIOS obj = new ANUNCIOS();
                    obj = _lista[i];
                    string fecha = Convert.ToDateTime(obj.FECHA_ANUNCIO).ToString("dddd dd, MMMM, yyyy");
                    string fila = obj.TITULO + "|" + obj.CUERPO + "|" + obj.REMITENTE + "|" + fecha;
                    lista.Add(fila);
                }

                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<string> ListarLibro(int condominio)
        {
            try
            {
                SigescoEntities bd = new SigescoEntities();
                var listaLibro = (from a in bd.LIBRO_SUCESOS
                                     where a.ID_CONDOMINIO == condominio
                                     orderby a.FECHA_SUCESO descending
                                     select a).Take(100).ToList();

                List<string> lista = new List<string>();
                List<LIBRO_SUCESOS> _lista = listaLibro;
                int x = _lista.Count();
                for (int i = 0; i < x; i++)
                {
                    LIBRO_SUCESOS obj = new LIBRO_SUCESOS();
                    obj = _lista[i];
                    string fecha = Convert.ToDateTime(obj.FECHA_SUCESO).ToString("dddd dd, MMMM, yyyy");
                    string fila = fecha + "|" + obj.REFERENCIA + "|" + obj.DETALLES;
                    lista.Add(fila);
                }

                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool GrabarLibro(LIBRO_SUCESOS nuevo)
        {
            try
            {
                SigescoEntities bd = new SigescoEntities();                
                using (bd)
                {
                    var listaLibro = (from a in bd.LIBRO_SUCESOS
                                      orderby a.ID_SUCESO descending
                                      select a.ID_SUCESO).FirstOrDefault();
                    nuevo.ID_SUCESO = listaLibro + 1;
                    bd.LIBRO_SUCESOS.Add(nuevo);
                    bd.SaveChanges();
                    return true;
                }
                   
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }//fin clase
}
