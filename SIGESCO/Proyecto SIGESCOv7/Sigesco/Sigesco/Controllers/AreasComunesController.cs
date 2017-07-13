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
    public class AreasComunesController : Controller
    {
        //
        // GET: /AreasComunes/

        public ActionResult VerAreas()
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

        public ActionResult VerAreasDir()
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

        public ActionResult VerAreasCons()
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

        public ActionResult VerAreasAdm()
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

        public ActionResult VerReservasDir()
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

        public ActionResult VerReservasCons()
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

        public ActionResult VerReservasAdm()
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

        public ActionResult AdmAreas()
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
        public JsonResult ObtenerEspaciosPorCondominio(FormCollection collection)
        {
            try
            {
                int condominio = int.Parse(collection["Condominio"].ToString());
                AreasComunesDAL area = new AreasComunesDAL();
                var model = area.GetAreasPorCondominio(condominio);
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
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
