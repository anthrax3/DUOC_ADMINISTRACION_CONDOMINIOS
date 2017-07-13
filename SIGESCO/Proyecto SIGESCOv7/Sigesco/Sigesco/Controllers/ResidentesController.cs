using SigescoDAL;
using SigescoDAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sigesco.Controllers
{
    public class ResidentesController : Controller
    {
        //
        // GET: /Residentes/

        public ActionResult VerResidentesDir()
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

        public ActionResult VerResidentesAdm()
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

        public ActionResult VerResidentesCons()
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

        public ActionResult RegistrarResidentesDir()
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

        public ActionResult RegistrarResidentesAdm()
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

        public ActionResult ResidentesMorososDir()
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

        public ActionResult ResidentesMorososCons()
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

        public ActionResult ResidentesMorososAdm()
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
        public JsonResult ObtenerInfoResidentes(FormCollection collection)
        {
            int condominio = int.Parse(collection["Condominio"].ToString());
            ResidenteDAL dal = new ResidenteDAL();
            var model = dal.ObtenerInfoResidentePorCondominio(condominio);
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
        public JsonResult CrearResidente(FormCollection collection)
        {
            PERSONA persona = new PERSONA();
            USUARIO usuario = new USUARIO();
            RESIDENTE residente = new RESIDENTE();
            USUARIO_X_CONDOMINIO uxc = new USUARIO_X_CONDOMINIO();
            var _rut = collection["Rut"].ToString().Split('-');
            persona.RUT = int.Parse(_rut[0]);
            persona.PRIMER_NOMBRE=collection["PrimerNom"].ToString();
            persona.SEGUNDO_NOMBRE = collection["SegNom"].ToString();
            persona.APELLIDO_PATERNO = collection["ApePat"].ToString();
            persona.APELLIDO_MATERNO = collection["ApeMat"].ToString();
            persona.FECHA_NACIMIENTO = Convert.ToDateTime(collection["Fecha"].ToString());
            string fono = collection["Fono"].ToString();
            if (fono == "")
            { persona.TELEFONO = null; }
            else
            { persona.TELEFONO = int.Parse(fono);}           
            persona.CORREO = collection["Email"].ToString();
            persona.SEXO = collection["Sexo"].ToString();
            usuario.ID_USUARIO = int.Parse('1' + _rut[0]);
            usuario.ID_TIPO_USUARIO = 1;
            usuario.RUT = int.Parse(_rut[0]);
            usuario.CLAVE=collection["Pass"].ToString();
            residente.ID_RESIDENTE = int.Parse(collection["Residencia"].ToString() + _rut[0]);
            residente.RUT = int.Parse(_rut[0]);
            residente.ID_VIVIENDA = int.Parse(collection["Residencia"].ToString());
            residente.FECHA_INGRESO = DateTime.Now;
            uxc.ID_USUARIO = usuario.ID_USUARIO;
            uxc.ID_CONDOMINIO = int.Parse(collection["Condominio"].ToString());
            uxc.ID_UXC = int.Parse(usuario.ID_USUARIO+collection["Condominio"].ToString());
            ResidenteDAL dal = new ResidenteDAL();
            var model = dal.AgregarPersonaUsuarioResidente(persona,usuario,residente,uxc);
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
        public JsonResult AsignarResidente(FormCollection collection)
        {
            RESIDENTE residente = new RESIDENTE();
            string _rut = collection["Persona"].ToString();
            residente.ID_RESIDENTE = int.Parse(collection["Residencia"].ToString() + _rut);
            residente.RUT = int.Parse(_rut);
            residente.ID_VIVIENDA = int.Parse(collection["Residencia"].ToString());
            residente.FECHA_INGRESO = DateTime.Now;
            ResidenteDAL dal = new ResidenteDAL();
            var model = dal.AgregarResidente(residente);
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
