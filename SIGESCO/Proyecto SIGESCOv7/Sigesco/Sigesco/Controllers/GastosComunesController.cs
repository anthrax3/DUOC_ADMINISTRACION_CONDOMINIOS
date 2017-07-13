using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SigescoDAL;
using SigescoDAL.Modelo;
using SigescoDAL.Vistas;
using Transbank.NET;
using Webpay.Transbank.Library;
using Webpay.Transbank.Library.Wsdl.Normal;
using Webpay.Transbank.Library.Wsdl.Nullify;

namespace Sigesco.Controllers
{
    public class GastosComunesController : Controller
    {
        //
        // GET: /GastosComunes/

        public ActionResult VerGastos()
        {
            if (Session["UserName"] != null )
            {                
                return View();
            }
            else
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }
        }
        
        public ActionResult CrearGastosAdm()
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

        public ActionResult EditarGastosAdm()
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
        
        public ActionResult VerGastosCons()
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

        public ActionResult VerGastosAdm()
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

        public ActionResult VerGastosDir()
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

        public ActionResult PagarGastos()
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

        public ActionResult PagarGastosCons()
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

        public ActionResult PagarGastosAdm()
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

        public ActionResult Morosidad()
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

        public ActionResult Observaciones()
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

        public ActionResult AdmGastos()
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
        public JsonResult ObtenerGastosPorId(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();
            int gasto = int.Parse(collection["Gasto"].ToString());
            var model = bd.GetGastoNoPagadoPorId(gasto);
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
        public JsonResult BuscarGastosPorRangoFechas(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();
            string fecha = collection["Hasta"].ToString();
            DateTime desde = Convert.ToDateTime(collection["Desde"].ToString());
            DateTime hasta = Convert.ToDateTime( fecha+" 23:59:00");
            int vivienda = int.Parse(collection["Vivienda"].ToString());
            var model = bd.ObtenerVistaGastosPorVivienda(vivienda,desde,hasta);
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
        public JsonResult BuscarGastosPorPagarPorRangoFechas(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();
            string fecha = collection["Hasta"].ToString();
            DateTime desde = Convert.ToDateTime(collection["Desde"].ToString());
            DateTime hasta = Convert.ToDateTime(fecha + " 23:59:00");
            int vivienda = int.Parse(collection["Vivienda"].ToString());
            var model = bd.ObtenerGastosPorPagarPorVivienda(vivienda, desde, hasta);
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
        public JsonResult BuscarMorosidadPorVivienda(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();
            int vivienda = int.Parse(collection["Vivienda"].ToString());
            var model = bd.ObtenerVistaMorosidadPorVivienda(vivienda);
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
        public JsonResult BuscarMorosidadPorCondominio(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();
            int condominio = int.Parse(collection["Condominio"].ToString());
            var model = bd.ObtenerVistaMorosidadPorCondominio(condominio);
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
        public JsonResult BuscarObservacionPorRangoFechas(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();
            string fecha = collection["Hasta"].ToString();
            DateTime desde = Convert.ToDateTime(collection["Desde"].ToString());
            DateTime hasta = Convert.ToDateTime(fecha + " 23:59:00");
            int vivienda = int.Parse(collection["Vivienda"].ToString());
            var model = bd.ObtenerVistaGastosPorVivienda(vivienda, desde, hasta);
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
        public JsonResult BuscarGastoParaCrearObservacionPorRangoFechas(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();
            string fecha = collection["Hasta"].ToString();
            DateTime desde = Convert.ToDateTime(collection["Desde"].ToString());
            DateTime hasta = Convert.ToDateTime(fecha + " 23:59:00");
            int vivienda = int.Parse(collection["Vivienda"].ToString());
            var model = bd.GetGastosSinObsPorVivienda(vivienda, desde, hasta);
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
        public JsonResult BuscarGastoParaEditarObservacionPorRangoFechas(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();
            string fecha = collection["Hasta"].ToString();
            DateTime desde = Convert.ToDateTime(collection["Desde"].ToString());
            DateTime hasta = Convert.ToDateTime(fecha + " 23:59:00");
            int vivienda = int.Parse(collection["Vivienda"].ToString());
            var model = bd.GetGastosConObsPorVivienda(vivienda, desde, hasta);
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
        public JsonResult ObtenerObervacionPorGasto(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();            
            int id = int.Parse(collection["Gasto"].ToString());
            var model = bd.GetObsPorGasto(id);
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
        public JsonResult AgragarObervacionPorGasto(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();
            int id = int.Parse(collection["Gasto"].ToString());
            string texto = collection["Texto"].ToString();
            var model = bd.ActualizarObervacionPorGasto(id,texto);
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
        public JsonResult GetGastoPorID(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();
            int id = int.Parse(collection["IdGasto"].ToString());
            var model = bd.getGastoPorID(id);
            if (model!=null)
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
        public JsonResult UpdateGastoPorID(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();
            GASTO actualizar = new GASTO(); 
            actualizar.ID_GASTO = int.Parse(collection["ID"].ToString());
            actualizar.NOMBRE_GASTO = collection["Nombre"].ToString();
            actualizar.DESCRIPCION = collection["Descripcion"].ToString();
            actualizar.ID_TIPO_GASTO = int.Parse(collection["Tipo"].ToString());
            actualizar.MONTO_GASTO = int.Parse(collection["Monto"].ToString());
            var model = bd.updateGastoPorID(actualizar);
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
        public JsonResult EliminarObervacionPorGasto(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();
            int id = int.Parse(collection["Gasto"].ToString());
            string texto = "";
            var model = bd.ActualizarObervacionPorGasto(id, texto);
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

        public JsonResult ObtenerInfoGastoPagadoPorFechaPorVivienda(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();
            string fecha = collection["Hasta"].ToString();
            DateTime desde = Convert.ToDateTime(collection["Desde"].ToString());
            DateTime hasta = Convert.ToDateTime(fecha + " 23:59:00");
            int residencia = int.Parse(collection["Residencia"].ToString());
            var model = bd.ObtenerVistaGastoPagoPorCondominioPorFecha(residencia, desde, hasta);
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
        public JsonResult ObtenerInfoGastoNoPagadaPorFechaPorVivienda(FormCollection collection)
        {
            GastosDAL bd = new GastosDAL();
            string fecha = collection["Hasta"].ToString();
            DateTime desde = Convert.ToDateTime(collection["Desde"].ToString());
            DateTime hasta = Convert.ToDateTime(fecha + " 23:59:00");
            int residencia = int.Parse(collection["Residencia"].ToString());
            var model = bd.ObtenerVistaGastoNoPagoPorCondominioPorFecha(residencia, desde, hasta);
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
        public JsonResult PagarGastosTransbank(FormCollection collection)
        {
            try
            {
                PagosDAL bd = new PagosDAL();
                PAGO nuevo = new PAGO();
                int monto = int.Parse(collection["Total"].ToString());
                string _gastos = collection["Gastos"].ToString();
                int tipo = 3;
                string[] gastos = _gastos.Split(',');
                nuevo.ID_TIPO_PAGO = tipo;
                nuevo.MONTO_PAGO = monto;
                nuevo.DOCUMENTO="TRANSBANK COMPROBANTE N° "+ monto.ToString() + DateTime.Now.DayOfYear.ToString() + tipo.ToString();
                nuevo.FECHA = DateTime.Now;
                int id_pago =bd.PagarGastoComun(nuevo, gastos);
                var model = id_pago.ToString()+';'+nuevo.DOCUMENTO;                                
                if(id_pago>0)
                {
                    var result = new { Success = true, Message = "Succes Message", model};
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var result = new { Success = false, Message = "Error Message" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }

            }catch(Exception ex)
            {
                var result = new { Success = false, Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult PagarGastosComunes(FormCollection collection)
        {
            try
            {
                PagosDAL bd = new PagosDAL();
                PAGO nuevo = new PAGO();
                int monto = int.Parse(collection["Total"].ToString());
                string _gastos = collection["Gastos"].ToString();
                int tipo = int.Parse(collection["TipoPago"].ToString());
                string[] gastos = _gastos.Split(',');
                nuevo.ID_TIPO_PAGO = tipo;
                nuevo.MONTO_PAGO = monto;
                nuevo.DOCUMENTO = "BOLETA - N° " + collection["NumeroBoleta"].ToString(); ;
                nuevo.FECHA = DateTime.Now;
                int id_pago = bd.PagarGastoComun(nuevo, gastos);
                var model = id_pago.ToString() + ';' + nuevo.DOCUMENTO;
                if (id_pago > 0)
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
            catch (Exception ex)
            {
                var result = new { Success = false, Message = "Error Message" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult CargarGatosMasivos(FormCollection collection)
        {
            GastosDAL db = new GastosDAL();
            List<GASTO> listaGasto = new List<GASTO>();
            var _arreglo = collection["Array"].ToString();
            var arreglo = _arreglo.Split(',');
            var nombre = collection["Nombre"].ToString();
            var descripcion = collection["Descripcion"].ToString();
            var fecha = Convert.ToDateTime(collection["Fecha"].ToString());
            var tipo = int.Parse(collection["Tipo"].ToString());
            var monto = int.Parse(collection["Monto"].ToString());
            int ulti = db.ultimo();
            int x=arreglo.Count();
            for(int i = 0;i<x;i++)
            {
                ulti = ulti + 1;
                GASTO gas = new GASTO();
                gas.ID_GASTO = ulti;
                gas.ID_TIPO_GASTO = tipo;
                gas.ID_VIVIENDA = int.Parse(arreglo[i]);
                gas.MONTO_GASTO = monto;
                gas.NOMBRE_GASTO = nombre;
                gas.DESCRIPCION = descripcion;
                gas.FECHA_GASTO = fecha;
                gas.ESTADO = "NO PAGADO";
                listaGasto.Add(gas);
            }
            
            var model = db.InsertarGastoMasivo(listaGasto);
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
