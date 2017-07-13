using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SigescoDAL;
using SigescoDAL.Modelo;
using SigescoDAL.Vistas;

namespace Sigesco.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/
        public ActionResult VerUsuario()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }
        }

        public ActionResult VerUsuarioAdm()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }
        }

        public ActionResult CrearUsuario()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }
        }

        public ActionResult EditarUsuario()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }
        }

        public ActionResult MiUsuario()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }
        }

        public ActionResult MiUsuarioCons()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }
        }
        public ActionResult MiUsuarioAdm()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }
            
        }

        public ActionResult ConfMiUsuarioSis()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }
        }

        public ActionResult ConfMiUsuarioAdm()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }
        }

        public ActionResult MiUsuarioDir()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }
        }

        public ActionResult ConfMiUsuario()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }
        }

        public ActionResult ConfMiUsuarioCons()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }
        }

        public ActionResult ConfMiUsuarioDir()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }
        }

        public ActionResult GestionaUsuariosAdm()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }
        }

        [HttpPost]
        public JsonResult ActualizarClave(FormCollection collection)
        {
            UsuarioDAL dal = new UsuarioDAL();
            string clave = collection["Clave"].ToString();
            int usuario = int.Parse(collection["Usuario"].ToString());
            var model = dal.ActualizarClave(clave,usuario);
            if (model)
            {
                var result = new { Success = true, Message = "Succes Message", model };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = false, Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult EliminarUsuario(FormCollection collection)
        {
            UsuarioDAL dal = new UsuarioDAL();
            int usuario = int.Parse(collection["Usuario"].ToString());
            var model = dal.EliminarUsuario(usuario);
            if (model)
            {
                var result = new { Success = true, Message = "Succes Message", model };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = false, Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult GetPersonas(FormCollection collection)
        {
            PersonaDAL dal = new PersonaDAL();
            var model = dal.GetPersonas();
            if (model != null)
            {
                var result = new { Success = true, Message = "Succes Message", model };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = false, Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ObtenerInfoUsuariosPorCondominio(FormCollection collection)
        {
            int usuario = int.Parse(Session["UserID"].ToString());
            int condominio = int.Parse(collection["Condominio"].ToString());
            UsuarioDAL dal = new UsuarioDAL();
            var model = dal.RetornarVistaUsuarioPorCondominio(usuario,condominio);
            if (model != null)
            {
                var result = new { Success = true, Message = "Succes Message", model };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = false, Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult ObtenerInfoUsuarioPorUsuario(FormCollection collection)
        {
            int usuario = int.Parse(Session["UserID"].ToString());            
            UsuarioDAL dal = new UsuarioDAL();
            var model = dal.RetornarDatosPersonaPorUsuario(usuario);            
            if (model != null)
            {
                var result = new { Success = true, Message = "Succes Message", model };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = false, Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult ObtenerUsuariosPorUsuario(FormCollection collection)
        {
            string usuario = Session["UserID"].ToString();
            UsuarioDAL dal = new UsuarioDAL();
            var rut = dal.RetronarRutUsuario(usuario);
            var model = dal.ObtenerUsuariosPorUsuario(int.Parse(rut));
            if (model != null)
            {
                var result = new { Success = true, Message = "Succes Message", model };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = false, Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpPost]
        public JsonResult ObtenerUsuariosPorPersona(FormCollection collection)
        {
            string usuario = collection["Persona"].ToString();
            UsuarioDAL dal = new UsuarioDAL();
            var model = dal.ObtenerUsuariosPorUsuario(int.Parse(usuario));
            if (model != null)
            {
                var result = new { Success = true, Message = "Succes Message", model };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = false, Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpPost]
        public JsonResult CrearUsuario(FormCollection collection)
        {

            PERSONA persona = new PERSONA();
            USUARIO usuario = new USUARIO();
            
            var _rut = collection["Rut"].ToString().Split('-');
            persona.RUT = int.Parse(_rut[0]);
            persona.PRIMER_NOMBRE = collection["PrimerNom"].ToString();
            persona.SEGUNDO_NOMBRE = collection["SegNom"].ToString();
            persona.APELLIDO_PATERNO = collection["ApePat"].ToString();
            persona.APELLIDO_MATERNO = collection["ApeMat"].ToString();
            persona.FECHA_NACIMIENTO = Convert.ToDateTime(collection["Fecha"].ToString());
            string fono = collection["Fono"].ToString();
            if (fono == "")
            { persona.TELEFONO = null; }
            else
            { persona.TELEFONO = int.Parse(fono); }
            persona.CORREO = collection["Email"].ToString();
            persona.SEXO = collection["Sexo"].ToString();
            usuario.ID_USUARIO = int.Parse('1' + _rut[0]);
            usuario.ID_TIPO_USUARIO = 1;
            usuario.RUT = int.Parse(_rut[0]);
            usuario.CLAVE = collection["Pass"].ToString();
            List<USUARIO_X_CONDOMINIO> lista = new List<USUARIO_X_CONDOMINIO>();
            var _condominios = collection["Condominios"].ToString().Split(',');
            for(int i = 1;i<_condominios.Length;i++)
            {
                USUARIO_X_CONDOMINIO uxc = new USUARIO_X_CONDOMINIO();
                uxc.ID_USUARIO = usuario.ID_USUARIO;
                uxc.ID_CONDOMINIO = int.Parse(_condominios[i]);
                uxc.ID_UXC = int.Parse(usuario.ID_USUARIO+_condominios[i]);
                lista.Add(uxc);
            }

            
            UsuarioDAL dal = new UsuarioDAL();
            var model = dal.AgregarPersonaUsuario(persona, usuario, lista);
            if (model != null)
            {
                var result = new { Success = true, Message = "Succes Message", model };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = false, Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult CrearSoloUsuario(FormCollection collection)
        {
            
            USUARIO usuario = new USUARIO();
            usuario.ID_USUARIO = int.Parse(collection["Perfil"].ToString()+ collection["Persona"].ToString());
            usuario.ID_TIPO_USUARIO = int.Parse(collection["Perfil"].ToString());
            usuario.RUT = int.Parse(collection["Persona"].ToString());
            usuario.CLAVE = collection["Clave"].ToString();

            UsuarioDAL dal = new UsuarioDAL();
            var model = dal.AgregarUsuarioCondominio(usuario);
            if (model != null)
            {
                var result = new { Success = true, Message = "Succes Message", model };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = false, Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult ActualizarUsuario(FormCollection collection)
        {
            string usuario = Session["UserID"].ToString();
            UsuarioDAL dal = new UsuarioDAL();
            var rut = dal.RetronarRutUsuario(usuario);
            PERSONA pers = new PERSONA();
            USUARIO usu = new USUARIO();
            pers.PRIMER_NOMBRE = collection["Primero"].ToString();
            pers.SEGUNDO_NOMBRE = collection["Segundo"].ToString();
            pers.APELLIDO_PATERNO = collection["ApPat"].ToString();
            pers.APELLIDO_MATERNO = collection["ApMat"].ToString();
            pers.FECHA_NACIMIENTO = Convert.ToDateTime(collection["Fecha"].ToString());
            pers.TELEFONO = int.Parse(collection["Fono"].ToString());
            pers.CORREO = collection["Correo"].ToString();
            pers.SEXO = collection["Sexo"].ToString();
            usu.RUT = int.Parse(rut);
            if(collection["Nueva"].ToString()!="")
            {
                usu.ID_USUARIO = int.Parse(usuario);
                usu.CLAVE= collection["Nueva"].ToString();
            }
            var model = dal.ActualizarUsuario(pers,usu);
            if (model)
            {
                var result = new { Success = true, Message = "Succes Message", model };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = false, Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpPost]
        public JsonResult AgragarCondominioUsuario(FormCollection collection)
        {
            UsuarioDAL dal = new UsuarioDAL();
            int usuario = int.Parse(collection["Usuario"].ToString());
            int condominio = int.Parse(collection["Condominio"].ToString());            
            var model = dal.AsignarNuevoCondominio(usuario, condominio);
            if (model)
            {
                var result = new { Success = true, Message = "Succes Message", model };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = new { Success = false, Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
