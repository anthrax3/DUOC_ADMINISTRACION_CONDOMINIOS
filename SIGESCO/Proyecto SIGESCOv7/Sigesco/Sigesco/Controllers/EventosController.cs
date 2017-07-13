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
    public class EventosController : Controller
    {
        //
        // GET: /Eventos/

        public ActionResult VerEventos()
        {
            return View();
        }

        public ActionResult AdmEventos()
        {
            return View();
        }

    }
}
