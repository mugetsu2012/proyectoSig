using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlEscuela.Core;
using ControlEscuela.Core.Model;
using ControlEscuela.Core.Model.Alumnos;
using ControlEscuela.Core.Model.Grados;
using ControlEscuela.Web.Helpers;
using ControlEscuela.Web.Models;

namespace ControlEscuela.Web.Controllers
{
    public class GradosController : Controller
    {
        private readonly IAdministracionService _administracionService;
        private readonly IGradosService _gradosService;
        private readonly ICatalogosService _catalogosService;

        public GradosController(IAdministracionService administracionService,
            IGradosService gradosService,
            ICatalogosService catalogosService)
        {
            _administracionService = administracionService;
            _gradosService = gradosService;
            _catalogosService = catalogosService;
        }


        // GET: Grados
        public ActionResult Listado(string nombreBuscar="", string nombreProfesor="", Enums.Turno turno= Enums.Turno.Todos)
        {
            GradoVm model = new GradoVm()
            {
                AgregarEditarSeccionGradoVm = new AgregarEditarSeccionGradoVm()
                {
                    Grados = _catalogosService.GetGrados(),
                    Profesores = _administracionService.GetListaProfesores("")
                },
                NombreBuscar = nombreBuscar,
                NombreProfesor = nombreProfesor,
                Turno = turno,
                SeccionesGrado = _gradosService.GetListaGrados(nombreBuscar, nombreProfesor, turno)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AgregarEditarSeccionGrado(AgregarEditarSeccionGradoVm agregarEditarSeccionGradoVm)
        {
            
            SeccionGrado seccionGrado = new SeccionGrado()
            {
                Codigo = agregarEditarSeccionGradoVm.Codigo,
                IdProfesor = agregarEditarSeccionGradoVm.IdProfesor,
                IdGrado = agregarEditarSeccionGradoVm.IdGrado,
                Turno = agregarEditarSeccionGradoVm.Turno
            };

            _gradosService.AgregarEditarSeccionGrado(seccionGrado);

            return RedirectToAction("Listado");
        }

        [HttpPost]
        public ActionResult GetSeccionGradoEdit(int idSeccionGrado)
        {
            SeccionGrado seccionGrado = _gradosService.GetSeccionGrado(idSeccionGrado);

            AgregarEditarSeccionGradoVm model = new AgregarEditarSeccionGradoVm()
            {
                Codigo = seccionGrado.Codigo,
                Turno = seccionGrado.Turno,
                IdGrado = seccionGrado.IdGrado,
                IdProfesor = seccionGrado.IdProfesor,
                Profesores = _administracionService.GetListaProfesores(),
                Grados = _catalogosService.GetGrados()
            };

            string stringPartial =
                this.ControllerContext.RenderPartialToString("~/Views/Grados/_FrmSeccionGrado.cshtml", model);

            return Json(new { partial = stringPartial }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RegistrarAsistencia()
        {
            return View();
        }
    }
}