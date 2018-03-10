using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscuela.Web.Controllers
{
    public class AdministracionController : Controller
    {
        // GET: Administracion
        public ActionResult ListaUsuarios()
        {
            return View();
        }

        public ActionResult ListadoDocentes()
        {
            return View();
        }
    }
}