using Sigesco.Models;
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
    public class InicioController : Controller
    {
        
        public ActionResult IniciarSesion()
        {
            this.Session["UserName"] = null;
            this.Session["UserID"] = null;
            this.Session["Perfil"] = null;
            this.Session["NomPerfil"] = null;
            return View("IniciarSesion");
        }
        
        
        
        [HttpPost]
        public JsonResult IniciarSesion(FormCollection collection)
        {
            string usuario = collection["Usuario"].ToString();
            string pass = collection["Clave"].ToString();
            UsuarioDAL dal = new UsuarioDAL();
            int valida = dal.ValidarUsuario(usuario,pass);
            int model = 0;
            if(valida==1)
            {
                model = 1;//usuario correcto y clave correcto
                Session["Perfil"] = dal.RetronarPerfilUsuario(usuario);
                Session["UserName"] = dal.RetronarUsuario(usuario);
                Session["UserID"] = usuario;
                string perf = Session["Perfil"].ToString(); 
                if(perf=="5")
                {
                    Session["NomPerfil"] = "Mantenimiento Sistemas";
                }
                if (perf == "4")
                {
                    Session["NomPerfil"] = "Administrador Condominio";
                }
                if (perf == "3")
                {
                    Session["NomPerfil"] = "Conserje";
                }
                if (perf == "2")
                {
                    Session["NomPerfil"] = "Directiva Condominio";
                }
                if (perf == "1")
                {
                    Session["NomPerfil"] = "Residente";
                }
            }
            else if(valida ==2)
            {
                model = 2;//clave erronea
            }


            if (valida!=5)
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
