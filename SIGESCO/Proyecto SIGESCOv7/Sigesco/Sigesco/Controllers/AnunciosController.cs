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
    public class AnunciosController : Controller
    {
        //
        // GET: /Anuncios/

        public ActionResult VerAnuncios()
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

        public ActionResult VerLibroCons()
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

        public ActionResult AgregarEventoCons()
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

        public ActionResult VerLibroAdm()
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

        public ActionResult AgregarEventoAdm()
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

        public ActionResult VerAnunciosDir()
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

        public ActionResult CrearAnunciosDir()
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

        public ActionResult VerAnunciosAdm()
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

        public ActionResult CrearAnunciosAdm()
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

        public ActionResult AdmAnuncios()
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
        public JsonResult Listar20Ultimos(FormCollection collection)
        {
            AnunciosDAL bd = new AnunciosDAL();
            int condominio = int.Parse(collection["Condominio"].ToString());
            var model = bd.Obtener20UltimosAuncios(condominio);
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
        public JsonResult ListarLibro(FormCollection collection)
        {
            AnunciosDAL bd = new AnunciosDAL();
            int condominio = int.Parse(collection["Condominio"].ToString());
            var model = bd.ListarLibro(condominio);
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
        public JsonResult GrabarLibro(FormCollection collection)
        {
            AnunciosDAL bd = new AnunciosDAL();
            LIBRO_SUCESOS libro = new LIBRO_SUCESOS();
            libro.ID_CONDOMINIO = int.Parse(collection["Condominio"].ToString());
            libro.REFERENCIA = (collection["Persona"].ToString()+" - "+collection["Perfil"].ToString());
            libro.DETALLES = collection["Cuerpo"].ToString();
            libro.FECHA_SUCESO = DateTime.Now;
            var model = bd.GrabarLibro(libro);
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
        public JsonResult CrearAnuncios(FormCollection collection)
        {
            AnunciosDAL bd = new AnunciosDAL();
            ANUNCIOS anun = new ANUNCIOS();
            anun.ID_CONDOMINIO = int.Parse(collection["Condominio"].ToString());
            anun.TITULO = collection["Titulo"].ToString();
            anun.CUERPO = collection["Cuerpo"].ToString();
            anun.REMITENTE = collection["Remitente"].ToString();
            anun.FECHA_ANUNCIO = DateTime.Now;
            var model = bd.CrearAnuncio(anun);
            if (model)
            {
                var result = new { Success = true, Message = "Succes Message"};
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
