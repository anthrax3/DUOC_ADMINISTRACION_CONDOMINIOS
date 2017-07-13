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
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Inicio()
        {
            if (Session["UserName"] != null) 
            {
                int perfil = int.Parse(Session["Perfil"].ToString());
                if (perfil == 1)
                {
                    return View();
                }
                if (perfil == 2)
                {
                    return RedirectToAction("InicioDirectiva", "Home");
                }
                if (perfil == 3)
                {
                    return RedirectToAction("InicioConserje", "Home");
                }
                if (perfil == 4)
                {
                    return RedirectToAction("InicioAdministrador", "Home");
                }
                if (perfil == 5)
                {
                    return RedirectToAction("InicioSistemas", "Home");
                }
                else
                {
                    return RedirectToAction("IniciarSesion", "Inicio");
                }
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }            
        }

        public ActionResult InicioDirectiva()
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
        public ActionResult InicioConserje()
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
        public ActionResult InicioAdministrador()
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
        public ActionResult InicioSistemas()
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


        [HttpGet]
        public JsonResult ultimoAnuncio(FormCollection collection)
        {
            AnunciosDAL bd = new AnunciosDAL();
            var model = bd.ultimoAnuncio();
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

       
    }//fin clase
}
