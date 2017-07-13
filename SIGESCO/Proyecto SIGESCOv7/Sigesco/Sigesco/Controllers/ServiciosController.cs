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
    public class ServiciosController : Controller
    {
        //
        // GET: /Servicios/

        public ActionResult ReservarServ()
        {
            return View();
        }

    }
}
