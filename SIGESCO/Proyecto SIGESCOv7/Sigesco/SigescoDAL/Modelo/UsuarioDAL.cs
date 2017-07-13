using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigescoDAL.Vistas;

namespace SigescoDAL.Modelo
{
    public class UsuarioDAL
    {

        public string AgregarPersonaUsuario(PERSONA persona, USUARIO usuario,List<USUARIO_X_CONDOMINIO> list)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    context.PERSONA.Add(persona);
                    context.USUARIO.Add(usuario);
                    context.SaveChanges();

                    int contar = list.Count();
                    for(int i=0;i<contar;i++)
                    {
                        context.USUARIO_X_CONDOMINIO.Add(list[i]);
                        context.SaveChanges();
                    }

                    return usuario.ID_USUARIO.ToString();
                }

            }
            catch (Exception e)
            {
                return "0";
            }
        }

        public string AgregarUsuarioCondominio(USUARIO usuario)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var validar = (from a in context.USUARIO
                                   where a.ID_USUARIO == usuario.ID_USUARIO
                                   select a.ID_USUARIO).FirstOrDefault();
                    if (validar == 0)
                    {
                        context.USUARIO.Add(usuario);
                        context.SaveChanges();
                        return usuario.ID_USUARIO.ToString();
                    }

                    return "0";
                }

            }
            catch (Exception e)
            {
                return "0";
            }
        }

        public List<string> RetornarVistaUsuarioPorCondominio(int usuario, int condominio)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.USUARIO
                                 join b in context.PERSONA on a.RUT equals b.RUT
                                 join c in context.TIPO_USUARIO on a.ID_TIPO_USUARIO equals c.ID_TIPO_USUARIO
                                 join d in context.USUARIO_X_CONDOMINIO on a.ID_USUARIO equals d.ID_USUARIO
                                 where d.ID_CONDOMINIO == condominio
                                 select new VistaInfoUsuarios
                                 {
                                     PRIMER_NOMBRE = b.PRIMER_NOMBRE,
                                     APELLIDO_PATERNO = b.APELLIDO_PATERNO,
                                     RUT = b.RUT,
                                     ID_USUARIO = a.ID_USUARIO,
                                     DESCRIPCION_TIPO = c.DESCRIPCION_TIPO
                                 }).ToList();

                    List<string> lista = new List<string>();
                    List<VistaInfoUsuarios> _lista = query;
                    int x = query.Count();
                    for (int i = 0; i < x; i++)
                    {
                        VistaInfoUsuarios obj = new VistaInfoUsuarios();
                        obj = _lista[i];
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
                        string fila = obj.PRIMER_NOMBRE +' '+ obj.APELLIDO_PATERNO + ";" + _rut + '-' + dv + ";" + obj.ID_USUARIO + ";" + obj.DESCRIPCION_TIPO;
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

        public string RetornarDatosPersonaPorUsuario(int usuario)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.PERSONA
                                 join b in context.USUARIO on a.RUT equals b.RUT
                                 where b.ID_USUARIO == usuario
                                 select a).SingleOrDefault();
                    PERSONA obj = query;
                        string fecha = Convert.ToDateTime(obj.FECHA_NACIMIENTO).ToString("dd/MM/yyyy");
                        string fila = obj.PRIMER_NOMBRE + ";" + obj.SEGUNDO_NOMBRE + ";" + obj.APELLIDO_PATERNO + ";" + 
                        obj.APELLIDO_MATERNO +';'+obj.RUT+';'+fecha+";"+obj.TELEFONO+';'+obj.CORREO+';'+obj.SEXO;
                    return fila;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<string> ObtenerUsuariosPorUsuario(int rut)
        {
            SigescoEntities context = new SigescoEntities();
            using (context)
            {
                var query = (from a in context.USUARIO
                             where a.RUT == rut
                             select a).ToList();

                List<string> lista = new List<string>();
                List<USUARIO> _lista = query;
                int x = query.Count();
                for (int i = 0; i < x; i++)
                {
                    USUARIO obj = new USUARIO();
                    obj = _lista[i];
                    string fila = obj.ID_USUARIO + ";" + obj.ID_TIPO_USUARIO;
                    lista.Add(fila);
                }

                return lista;
            }
        }

        public bool ActualizarClave(string clave, int usuario)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.USUARIO
                                 where a.ID_USUARIO == usuario
                                 select a).FirstOrDefault();

                    if(query.ID_USUARIO!=0)
                    {
                        query.CLAVE = clave;
                        context.SaveChanges();
                        return true;
                    }
                    return false;

                }
            }catch(Exception e)
            {
                return false;
            }
        }

        public bool EliminarUsuario( int usuario)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query1 = (from a in context.USUARIO
                                 where a.ID_USUARIO == usuario
                                 select a).FirstOrDefault();

                    var query2 = (from a in context.USUARIO_X_CONDOMINIO
                                  where a.ID_USUARIO == usuario
                                  select a).ToList();

                    int x = query2.Count();
                    for(int i = 0;i<x;i++)
                    {
                        context.USUARIO_X_CONDOMINIO.Remove(query2[i]);
                    }                  
                    context.USUARIO.Remove(query1);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ActualizarUsuario(PERSONA pers,USUARIO usu)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.PERSONA
                                 where a.RUT == usu.RUT
                                 select a).FirstOrDefault();
                    PERSONA persona = query;
                    persona.PRIMER_NOMBRE = pers.PRIMER_NOMBRE;
                    persona.SEGUNDO_NOMBRE = pers.SEGUNDO_NOMBRE;
                    persona.APELLIDO_PATERNO = pers.APELLIDO_PATERNO;
                    persona.APELLIDO_MATERNO = pers.APELLIDO_MATERNO;
                    persona.FECHA_NACIMIENTO = pers.FECHA_NACIMIENTO;
                    persona.TELEFONO = pers.TELEFONO;
                    persona.CORREO = pers.CORREO;
                    persona.SEXO = pers.SEXO;
                    context.SaveChanges();
                    if(usu.CLAVE!=null)
                    {
                        var query2 = (from a in context.USUARIO
                                     where a.ID_USUARIO == usu.ID_USUARIO
                                     select a).FirstOrDefault();
                        USUARIO usuario = query2;
                        usuario.CLAVE = usu.CLAVE;
                        context.SaveChanges();
                    }

                    return true;
                }
            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool AsignarNuevoCondominio(int usuario, int condominio)
        {
            try
            {
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var query = (from a in context.USUARIO_X_CONDOMINIO
                                 where a.ID_USUARIO == usuario &&
                                 a.ID_CONDOMINIO == condominio
                                 select a.ID_USUARIO).FirstOrDefault();
                    if(query==0)
                    {
                        USUARIO_X_CONDOMINIO usu = new USUARIO_X_CONDOMINIO();
                        usu.ID_USUARIO = usuario;
                        usu.ID_CONDOMINIO = condominio;
                        usu.ID_UXC = int.Parse(usuario.ToString() + condominio.ToString());
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int ValidarUsuario(string usuario, string clave)
        {
            try
            {
                int _rut = int.Parse(usuario);
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var q_select_usuario = from obj in context.USUARIO
                                           where obj.ID_USUARIO == _rut
                                           select obj.ID_USUARIO; 

                    var q_select_clave = from obj in context.USUARIO
                                         where obj.ID_USUARIO == _rut
                                         select obj.CLAVE;   
                                     
                    var _usuario = q_select_usuario.SingleOrDefault();

                    var _clave = q_select_clave.SingleOrDefault();

                    if (usuario == _usuario.ToString() && clave == _clave)
                    {
                        return 1;
                    }
                    else if (usuario == _usuario.ToString() && clave != _clave)
                    {
                        return 2;
                    }
                    else { return 0; }
                }               
            }
            catch (Exception e)
            {
                return 5;
            }
        }

        
        public string RetronarUsuario(string usuario)
        {
            try
            {
                int _usuario=int.Parse(usuario);
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var _usuarioRut = from obj in context.USUARIO where obj.ID_USUARIO == _usuario
                                           select obj.RUT;
                    int _rut = int.Parse(_usuarioRut.Single().ToString());
                    var _usuarioNombre = (from obj in context.PERSONA
                                         where obj.RUT == _rut
                                         select obj).FirstOrDefault();
                    PERSONA pers = _usuarioNombre;
                    string nombreUsuario = pers.PRIMER_NOMBRE+" "+pers.APELLIDO_PATERNO;
                    return nombreUsuario; 
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public int RetronarPerfilUsuario(string usuario)
        {
            try
            {
                int _usuario = int.Parse(usuario);
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var _usuarioRut = (from obj in context.USUARIO
                                       where obj.ID_USUARIO == _usuario
                                       select obj.ID_TIPO_USUARIO).SingleOrDefault();                  
                    
                    return int.Parse(_usuarioRut.ToString());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public string RetronarRutUsuario(string usuario)
        {
            try
            {
                int _usuario = int.Parse(usuario);
                SigescoEntities context = new SigescoEntities();
                using (context)
                {
                    var _usuarioRut = from obj in context.USUARIO
                                      where obj.ID_USUARIO == _usuario
                                      select obj.RUT;
                    string _rut = _usuarioRut.Single().ToString();
                    
                    return _rut;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }



    }//fin Clase UsuarioDAL
}
