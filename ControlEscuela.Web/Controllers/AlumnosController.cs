using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscuela.Web.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Listado()
        {
            return View();
        }

        public ActionResult AgregarEditar()
        {
            return View();
        }
    }
}