using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscuela.Web.Controllers
{
    public class AsignaturasController : Controller
    {
        // GET: Asignaturas
        public ActionResult Listado()
        {
            return View();
        }
        
    }
}