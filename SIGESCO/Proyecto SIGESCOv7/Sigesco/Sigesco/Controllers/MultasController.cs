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
    public class MultasController : Controller
    {
        //
        // GET: /Multas/

        public ActionResult VerMultas()
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

        public ActionResult VerPagos()
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

        public ActionResult AdmMultas()
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

        public ActionResult IngresarMultasDir()
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

        public ActionResult VerPagosMultasDir()
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

        public ActionResult VerPagosMultasCons()
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

        public ActionResult VerPagosMultasAdm()
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

        public ActionResult VerPagosMultasResidenteCons()
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

        public ActionResult VerPagosMultasResidenteAdm()
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
        public JsonResult ObtenerMultasPorVivienda(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();
            int vivienda = int.Parse(collection["Vivienda"].ToString());
            var model = bd.ObtenerVistaMultasPorVivienda(vivienda);
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
        public JsonResult IngresarMulta(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();
            GASTO multa = new GASTO();
            multa.NOMBRE_GASTO = "Multa";
            multa.FECHA_GASTO = DateTime.Now;
            multa.ID_TIPO_GASTO = 4;
            multa.ESTADO = "NO PAGADO";
            multa.ID_VIVIENDA = int.Parse(collection["Vivienda"].ToString());
            multa.DESCRIPCION = collection["Descipcion"].ToString();
            multa.MONTO_GASTO = int.Parse(collection["Monto"].ToString());
            var model = bd.IngresarNuevaMulta(multa);
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
        public JsonResult ObtenerInfoMultaPagadaPorFechaPorCondominio(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();
            string fecha = collection["Hasta"].ToString();
            DateTime desde = Convert.ToDateTime(collection["Desde"].ToString());
            DateTime hasta = Convert.ToDateTime(fecha + " 23:59:00");
            int condominio = int.Parse(collection["Condominio"].ToString());
            var model = bd.ObtenerVistaMultasPagaPorCondominioPorFecha(condominio,desde,hasta);
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
        public JsonResult ObtenerInfoMultaNoPagadaPorFechaPorCondominio(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();
            string fecha = collection["Hasta"].ToString();
            DateTime desde = Convert.ToDateTime(collection["Desde"].ToString());
            DateTime hasta = Convert.ToDateTime(fecha + " 23:59:00");
            int condominio = int.Parse(collection["Condominio"].ToString());
            var model = bd.ObtenerVistaMultasNoPagaPorCondominioPorFecha(condominio, desde, hasta);
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
