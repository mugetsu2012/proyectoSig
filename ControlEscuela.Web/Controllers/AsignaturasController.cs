using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlEscuela.Core;
using ControlEscuela.Core.Model.Asignaturas;
using ControlEscuela.Web.Helpers;
using ControlEscuela.Web.Models;

namespace ControlEscuela.Web.Controllers
{
    public class AsignaturasController : Controller
    {
        private readonly IAsignaturaService _asignaturaService;

        public AsignaturasController(IAsignaturaService asignaturaService)
        {
            _asignaturaService = asignaturaService;
        }

        // GET: Asignaturas
        public ActionResult Listado(string nombreBuscar="")
        {
            MateriasVm model = new MateriasVm()
            {
                NombreBuscar = nombreBuscar,
                AgregarEditarMateriaVm = new AgregarEditarMateriaVm(),
                Asignaturas = _asignaturaService.GetAsignaturas(nombreBuscar)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult GetFormAsignatura(int idAsignatura)
        {
            Asignatura asignatura = _asignaturaService.GetAsignatura(idAsignatura);
            AgregarEditarMateriaVm model = new AgregarEditarMateriaVm()
            {
                Codigo = asignatura.Codigo,
                Nombre = asignatura.Nombre
            };

            string partial =
                this.ControllerContext.RenderPartialToString("~/Views/Asignaturas/_FrmMateria.cshtml", model);

            return Json(new {partial = partial}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AgregarEditarAsignatura(AgregarEditarMateriaVm agregarEditarMateriaVm)
        {
            _asignaturaService.IngresarEditarAsignatura(agregarEditarMateriaVm.Codigo, agregarEditarMateriaVm.Nombre);
            return RedirectToAction("Listado");
        }
        
    }
}