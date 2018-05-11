using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlEscuela.Core;
using ControlEscuela.Core.Model.Alumnos;
using ControlEscuela.Web.Models;

namespace ControlEscuela.Web.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly IAlumnosService _alumnosService;
        private readonly IGradosService _gradosService;
        private readonly ICatalogosService _catalogosService;

        public AlumnosController(IAlumnosService alumnosService,
            IGradosService gradosService,
            ICatalogosService catalogosService)
        {
            _alumnosService = alumnosService;
            _gradosService = gradosService;
            _catalogosService = catalogosService;
        }

        // GET: Alumnos
        public ActionResult Listado(string nombre="", string nie = "", int idSeccionGrado = 0)
        {
            ListadoAlumnosVm model = new ListadoAlumnosVm()
            {
                Nombre = nombre,
                IdSeccionGrado = idSeccionGrado,
                Nie = nie,
                SeccionesGrado = _catalogosService.GetSeccionesGrados(),
                Estudiantes = _alumnosService.GetListaEstudiantes(nombre,nie,idSeccionGrado)
            };

            return View(model);
        }

        
        public ActionResult Alumno(int idAlumno = 0)
        {
            AgregarEditarAlumnoVm model = new AgregarEditarAlumnoVm();
            if (idAlumno != 0)
            {
                Estudiante estudiante = _alumnosService.GetEstudiante(idAlumno);
                model.Apellidos = estudiante.Apellidos;
                model.Direccion = estudiante.Direccion;
                model.FechaNacimiento = estudiante.FechaNacimiento;
                model.IdSeccionGrado = estudiante.IdSeccionGrado;
                model.Nie = estudiante.Nie;
                model.NombreEncargado = estudiante.NombreEncargado;
                model.Nombres = estudiante.Nombres;
                model.TelefonoEncargado = estudiante.TelefonoEncargado;
                model.Codigo = estudiante.Codigo;
            }

            model.SeccionesGrado = _catalogosService.GetSeccionesGrados();
            return View(model);
        }

        [HttpPost]
        public ActionResult AgregarEditarAlumno(AgregarEditarAlumnoVm agregarEditarAlumnoVm)
        {
            Estudiante estudiante = new Estudiante()
            {
                Activo = agregarEditarAlumnoVm.Activo,
                Apellidos = agregarEditarAlumnoVm.Apellidos,
                Codigo = agregarEditarAlumnoVm.Codigo,
                Direccion = agregarEditarAlumnoVm.Direccion,
                FechaNacimiento = agregarEditarAlumnoVm.FechaNacimiento,
                IdSeccionGrado = agregarEditarAlumnoVm.IdSeccionGrado,
                Nie = agregarEditarAlumnoVm.Nie,
                NombreEncargado = agregarEditarAlumnoVm.NombreEncargado,
                Nombres = agregarEditarAlumnoVm.Nombres,
                TelefonoEncargado = agregarEditarAlumnoVm.TelefonoEncargado,

            };

            _alumnosService.AgregarEditarEstudiante(estudiante);

            return RedirectToAction("Alumno", new {idAlumno = estudiante.Codigo});
        }

        [HttpPost]
        public ActionResult ToggleEstadoAlumno(int idAlumno)
        {
            _alumnosService.ActivarDesactivarEstudiante(idAlumno);
            return RedirectToAction("Listado");
        }
    }
}