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
    public class CondominiosController : Controller
    {
        //
        // GET: /Condominios/

        public ActionResult CrearCondominio()
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

        public ActionResult CrearViviendas()
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

        public ActionResult CrearEspacios()
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

        public ActionResult CrearSA()
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
        public JsonResult GetRegiones(FormCollection collection)
        {
            try
            {
                CondominioDAL cond = new CondominioDAL();
                var model = cond.GetRegiones();
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


        [HttpPost]
        public JsonResult GetCondominios(FormCollection collection)
        {
            try
            {
                CondominioDAL cond = new CondominioDAL();
                var model = cond.GetCondominios();
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

        [HttpPost]
        public JsonResult GetViviendas(FormCollection collection)
        {
            try
            {
                CondominioDAL cond = new CondominioDAL();
                var model = cond.GetViviendas();
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

        public JsonResult GetEspacios(FormCollection collection)
        {
            try
            {
                CondominioDAL cond = new CondominioDAL();
                var model = cond.GetEspacios();
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

        [HttpPost]
        public JsonResult GetComunas(FormCollection collection)
        {
            try
            {
                CondominioDAL cond = new CondominioDAL();                
                var model = cond.GetComunas(int.Parse(collection["Region"]));
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

        [HttpPost]
        public JsonResult CrearCondominio(FormCollection collection)
        {
            try
            {
                CondominioDAL cond = new CondominioDAL();
                CONDOMINIO nuevo = new CONDOMINIO();
                nuevo.ID_COMUNA = int.Parse(collection["comuna"].ToString());
                nuevo.NOMBRE = collection["nombre"].ToString();
                nuevo.DIRECCION = collection["direccion"].ToString();
                string num = collection["numerodire"].ToString();
                nuevo.NUMERO_DIRECCION = int.Parse(num);
                nuevo.TELEFONO = int.Parse(collection["fono"].ToString());

                var model = cond.InsertarCondominio(nuevo);
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
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public JsonResult CrearVivienda(FormCollection collection)
        {
            try
            {
                CondominioDAL cond = new CondominioDAL();
                VIVIENDA nuevo = new VIVIENDA();
                nuevo.ID_CONDOMINIO = int.Parse(collection["condominio"].ToString());
                nuevo.NOMBRE_CALLE = collection["direccion"].ToString();
                nuevo.NUMERO = collection["numerodire"].ToString();
                nuevo.PLANTA_UBICACION = collection["planta"].ToString();

                var model = cond.InsertarVivienda(nuevo);
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
            catch (Exception e)
            {
                throw e;
            }
            
        }


        public JsonResult CrearEspacio(FormCollection collection)
        {
            try
            {
                CondominioDAL cond = new CondominioDAL();
                ESPACIOS_COMUNES nuevo = new ESPACIOS_COMUNES();
                nuevo.ID_CONDOMINIO = int.Parse(collection["condominio"].ToString());
                nuevo.NOMBRE_ESPACIO = collection["nombre"].ToString();
                nuevo.DESCRIPCION_ESPACIO = collection["descripcion"].ToString();

                var model = cond.InsertarEspacio(nuevo);
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
            catch (Exception e)
            {
                throw e;
            }
            
        }


        [HttpPost]
        public JsonResult ObtenerResidenciasPorCondominio(FormCollection collection)
        {
            try
            {
                int condominio = int.Parse(collection["Condominio"].ToString());
                CondominioDAL cond = new CondominioDAL();
                var model = cond.GetViviendasPorCondominio(condominio);
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

        [HttpPost]
        public JsonResult ObtenerInfoCondominiosPorUsuario(FormCollection collection)
        {
            try
            {
                int usuario = int.Parse(Session["UserID"].ToString());
                CondominioDAL cond = new CondominioDAL();
                var model = cond.RetronarVistaInfoCondominios(usuario);
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




        [HttpPost]
        public JsonResult ObtenerInfoViviendasPorResidente(FormCollection collection)
        {
            try
            {
                string usuario = Session["UserID"].ToString();
                CondominioDAL cond = new CondominioDAL();
                var model=cond.RetronarVistaInfoVivienda(usuario);
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

        [HttpPost]
        public JsonResult ObtenerViviendasPorUsuario(FormCollection collection)
        {
            try
            {
                string usuario = collection["Usuario"].ToString();
                CondominioDAL cond = new CondominioDAL();
                var model = cond.GetViviendasPorUsuario(usuario);
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

        [HttpPost]
        public JsonResult ObtenerViviendasPorUsuarioPorUsuario(FormCollection collection)
        {
            try
            {
                int condominio = int.Parse(collection["Condominio"].ToString());
                string usuario = collection["Usuario"].ToString();
                CondominioDAL cond = new CondominioDAL();
                var model = cond.GetViviendasPorUsuarioPorCondominio(usuario,condominio);
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

        [HttpPost]
        public JsonResult ObtenerCondominiosPorUsuario(FormCollection collection)
        {
            try
            {
                string usuario = collection["Usuario"].ToString();
                CondominioDAL cond = new CondominioDAL();
                var model = cond.GetCondominioPorUsuario(usuario);
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

    }//fin clase
}
