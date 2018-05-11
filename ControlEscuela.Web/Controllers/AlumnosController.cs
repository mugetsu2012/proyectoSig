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

        public AlumnosController(IAlumnosService alumnosService)
        {
            _alumnosService = alumnosService;
        }

        // GET: Alumnos
        public ActionResult Listado()
        {
            return View();
        }

        public ActionResult AgregarEditar(int idAlumno = 0)
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
            }

            return View(model);
        }
    }
}