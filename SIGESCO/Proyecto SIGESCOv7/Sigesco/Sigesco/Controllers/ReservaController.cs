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
    public class ReservaController : Controller
    {
        //
        // GET: /Reserva/
        public ActionResult VerReservas()
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

        public ActionResult ReservarCons()
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

        public ActionResult ReservarAdm()
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

        public ActionResult HabilitarReservarCons()
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

        public ActionResult HabilitarReservarAdm()
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


        public ActionResult Reservar()
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

        public ActionResult AdmReservas()
        {
            return View();
        }
        

        [HttpPost]
        public JsonResult ReservasPorVivienda(FormCollection collection)
        {
            ReservaDAL bd = new ReservaDAL();
            int vivienda = int.Parse(collection["Vivienda"].ToString());
            var model = bd.ObtenerVistaReservasPorVivienda(vivienda);
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
        public JsonResult ReservasPorEspacio(FormCollection collection)
        {
            ReservaDAL bd = new ReservaDAL();
            int espacio = int.Parse(collection["EC_ID_ESPACIO"].ToString());
            var model = bd.ObtenerVistaReservasPorEspacio(espacio);
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
        public JsonResult ReservasPorEspacioSolicitado(FormCollection collection)
        {
            ReservaDAL bd = new ReservaDAL();
            int espacio = int.Parse(collection["EC_ID_ESPACIO"].ToString());
            var model = bd.ObtenerVistaReservasPorEspacioSolicitado(espacio);
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
        public JsonResult ReservasPorViviendaSolicitado(FormCollection collection)
        {
            ReservaDAL bd = new ReservaDAL();
            int vivienda = int.Parse(collection["Vivienda"].ToString()); 
                int espacio = int.Parse(collection["Espacio"].ToString());
            var model = bd.ObtenerVistaReservasPorViviendaSolicitado(vivienda, espacio);
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
        public JsonResult ReservarEspacioResidente(FormCollection collection)
        {
            ReservaDAL bd = new ReservaDAL();
            RESERVA nuevo = new RESERVA();
            DateTime ahora = DateTime.Now;
            nuevo.ID_RESERVA = 0;
            nuevo.ID_VIVIENDA = int.Parse(collection["Vivienda"].ToString());
            nuevo.FECHA_SOLICITUD = ahora;
            nuevo.FECHA_RESERVADA = Convert.ToDateTime(collection["Fecha"].ToString());
            nuevo.ID_ESPACIO= int.Parse(collection["Espacio"].ToString());
            nuevo.ESTADO_RESERVA = "SOLICITADO";
            var model = bd.AgregarNuevaReserva(nuevo);
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
        public JsonResult ReservarEspacioConserje(FormCollection collection)
        {
            ReservaDAL bd = new ReservaDAL();
            RESERVA nuevo = new RESERVA();
            DateTime ahora = DateTime.Now;
            nuevo.ID_RESERVA = 0;
            nuevo.ID_VIVIENDA = int.Parse(collection["Vivienda"].ToString());
            nuevo.FECHA_SOLICITUD = ahora;
            nuevo.FECHA_RESERVADA = Convert.ToDateTime(collection["Fecha"].ToString());
            nuevo.ID_ESPACIO = int.Parse(collection["Espacio"].ToString());
            nuevo.ESTADO_RESERVA = "RESERVADO";
            var model = bd.AgregarNuevaReserva(nuevo);
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
        public JsonResult ArpobarReservaConserje(FormCollection collection)
        {
            ReservaDAL bd = new ReservaDAL();
            RESERVA nuevo = new RESERVA();
            DateTime ahora = DateTime.Now;
            nuevo.ID_RESERVA = int.Parse(collection["Reserva"].ToString());
            nuevo.ESTADO_RESERVA = collection["Accion"].ToString();
            var model = bd.AprobarReserva(nuevo);
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


    }//fin clase
}
