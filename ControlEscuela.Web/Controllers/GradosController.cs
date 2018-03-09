using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscuela.Web.Controllers
{
    public class GradosController : Controller
    {
        // GET: Grados
        public ActionResult Listado()
        {
            return View();
        }

        public ActionResult RegistrarAsistencia()
        {
            return View();
        }
    }
}