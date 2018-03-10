using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscuela.Web.Controllers
{
    public class GestionController : Controller
    {
        // GET: Gestion
        public ActionResult Actividades()
        {
            return View();
        }

        public ActionResult Periodos()
        {
            return View();
        }

        public ActionResult Calificar()
        {
            return View();
        }
    }
}