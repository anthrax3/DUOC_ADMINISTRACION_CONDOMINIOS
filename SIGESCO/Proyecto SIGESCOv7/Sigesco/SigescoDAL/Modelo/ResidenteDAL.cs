using SigescoDAL.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigescoDAL.Modelo
{
    public class ResidenteDAL
    {
        public List<string> ObtenerInfoResidentePorCondominio(int condominio)
        {
            try
            {
                UsuarioDAL usuarioDal = new UsuarioDAL();
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.CONDOMINIO
                                 join b in context.VIVIENDA on a.ID_CONDOMINIO equals b.ID_CONDOMINIO
                                 join c in context.RESIDENTE on b.ID_VIVIENDA equals c.ID_VIVIENDA
                                 join d in context.PERSONA on c.RUT equals d.RUT
                                 join e in context.USUARIO on d.RUT equals e.RUT 
                                 join f in context.TIPO_USUARIO on e.ID_TIPO_USUARIO equals f.ID_TIPO_USUARIO
                                 where a.ID_CONDOMINIO == condominio && e.ID_TIPO_USUARIO == 1
                                 select new VistaInfoResidentesPorCondominio
                                 {
                                     NOMBRE_CALLE = b.NOMBRE_CALLE,
                                     NUMERO = b.NUMERO,
                                     PRIMER_NOMBRE = d.PRIMER_NOMBRE,
                                     APELLIDO_PATERNO = d.APELLIDO_PATERNO,
                                     RUT = d.RUT,
                                     CORREO=d.CORREO,
                                     TELEFONO = d.TELEFONO,
                                     DESCRIPCION_TIPO = f.DESCRIPCION_TIPO
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaInfoResidentesPorCondominio> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {                        
                        var obj = _lista[i];
                        string fono = obj.TELEFONO.ToString();
                        string correo = obj.CORREO.ToString();
                        int rut = int.Parse(obj.RUT.ToString());
                        string _rut = obj.RUT.ToString();
                        string dv = "";
                        if (fono == "")
                            fono = "NO INDICADO";
                        if (correo == "")
                            correo = "NO INDICADO";
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
                            dv= "0";
                        else if (suma == 10)
                            dv= "K";
                        else
                            dv= suma.ToString();
                        string fila = obj.NOMBRE_CALLE + " #" + obj.NUMERO + ";" + obj.PRIMER_NOMBRE + " " + obj.APELLIDO_PATERNO + ";" + _rut+'-'+dv + ";" + correo + ";" + fono+";"+obj.DESCRIPCION_TIPO;
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


        public string AgregarPersonaUsuarioResidente(PERSONA persona, USUARIO usuario, RESIDENTE residente, USUARIO_X_CONDOMINIO uxc)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    context.PERSONA.Add(persona);
                    context.USUARIO.Add(usuario);
                    context.RESIDENTE.Add(residente);
                    context.SaveChanges();

                    var query = from a in context.USUARIO_X_CONDOMINIO
                                where a.ID_USUARIO == uxc.ID_USUARIO
                                && a.ID_CONDOMINIO == uxc.ID_CONDOMINIO
                                select a.ID_USUARIO;

                    if(query==null)
                    {
                        context.USUARIO_X_CONDOMINIO.Add(uxc);
                    }

                    return usuario.ID_USUARIO.ToString();
                }                    

            }catch(Exception e)
            {
                return "0";
            }
        }

        public string AgregarResidente(RESIDENTE residente)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    context.RESIDENTE.Add(residente);
                    context.SaveChanges();

                    var query1 = (from a in context.USUARIO
                                 where a.RUT == residente.RUT
                                 select a.ID_USUARIO).FirstOrDefault().ToString();
                    int usuario = int.Parse(query1);
                    var query2 = (from a in context.VIVIENDA
                                 join b in context.CONDOMINIO on a.ID_CONDOMINIO equals b.ID_CONDOMINIO
                                 where a.ID_VIVIENDA == residente.ID_VIVIENDA
                                 select b.ID_CONDOMINIO).FirstOrDefault().ToString();
                    int condomino = int.Parse(query2);
                    var query3 = (from a in context.USUARIO_X_CONDOMINIO
                                 where a.ID_CONDOMINIO == condomino
                                 && a.ID_USUARIO == usuario
                                 select a).FirstOrDefault();

                    if (query3 == null)
                    {
                        if (usuario > 0 && condomino > 0)
                        {
                            USUARIO_X_CONDOMINIO uxc = new USUARIO_X_CONDOMINIO();
                            uxc.ID_CONDOMINIO = condomino;
                            uxc.ID_USUARIO = usuario;
                            uxc.ID_UXC = int.Parse(usuario.ToString() + condomino.ToString());
                            context.USUARIO_X_CONDOMINIO.Add(uxc);
                        }
                    }
                }
                return "Creado";
            }
            catch (Exception e)
            {
                return "0";
            }
        }

    }//fin clase
}
