using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ControlEscuela.Core;
using ControlEscuela.Core.Model;
using ControlEscuela.Core.Model.Alumnos;
using ControlEscuela.Core.Model.Usuarios;
using ControlEscuela.Web.Helpers;
using ControlEscuela.Web.Models;

namespace ControlEscuela.Web.Controllers
{
    public class AdministracionController : Controller
    {
        private readonly IAdministracionService _administracionService;

        public AdministracionController(IAdministracionService administracionService)
        {
            _administracionService = administracionService;
        }

        // GET: Administracion
        public ActionResult ListaUsuarios(string nombreUsuario="",int idRol=0,Enums.Estado estado = Enums.Estado.Todos)
        {
            UsuariosVm model = new UsuariosVm()
            {
                AgregarEditarUsuarioVm = new AgregarEditarUsuarioVm()
                {
                    Roles = _administracionService.GetRoles()
                },
                Estado = estado,
                IdRol = idRol,
                NombreUsuario = nombreUsuario,
                Usuarios = _administracionService.GetListaUsuarios(nombreUsuario, idRol, estado)
            };


            return View(model);
        }

        [HttpPost]
        public ActionResult AgregarEditarUsuario(AgregarEditarUsuarioVm agregarEditarUsuarioVm)
        {
            if (!agregarEditarUsuarioVm.EsEditar)
            {
                Usuario usuario = new Usuario()
                {
                    Password = UtilidadesMvc.GetPassEncrypt(agregarEditarUsuarioVm.Password),
                    IdRol = agregarEditarUsuarioVm.IdRol,
                    IdUsuario = agregarEditarUsuarioVm.NombreUsuario,
                    Activo = agregarEditarUsuarioVm.Activo
                };

                _administracionService.AgregarEditarUsuario(usuario, agregarEditarUsuarioVm.EsEditar);

            }
            else
            {
                Usuario userTest = _administracionService.GetUsuario(agregarEditarUsuarioVm.NombreUsuario);
                Usuario usuario = new Usuario()
                {
                    Password = agregarEditarUsuarioVm.Password == "dummy"? userTest.Password : UtilidadesMvc.GetPassEncrypt(agregarEditarUsuarioVm.Password),
                    IdRol = agregarEditarUsuarioVm.IdRol,
                    IdUsuario = agregarEditarUsuarioVm.NombreUsuario,
                    Activo = agregarEditarUsuarioVm.Activo
                };

                _administracionService.AgregarEditarUsuario(usuario, agregarEditarUsuarioVm.EsEditar);
            }
            

            
            return RedirectToAction("ListaUsuarios");
        }

        [HttpPost]
        public ActionResult GetUsuarioEdit(string idUsuario)
        {
            Usuario usuario = _administracionService.GetUsuario(idUsuario);

            AgregarEditarUsuarioVm model = new AgregarEditarUsuarioVm()
            {
                Activo = usuario.Activo,
                IdRol = usuario.IdRol,
                NombreUsuario = usuario.IdUsuario,
                Password = "dummy",
                EsEditar = true,
                Roles = _administracionService.GetRoles()
            };

            string stringPartial =
                this.ControllerContext.RenderPartialToString("~/Views/Administracion/_FrmUsuarios.cshtml", model);

            return Json(new { partial = stringPartial }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult ToggleEstadoUsuario(string idUsuario)
        {
            _administracionService.ToggleEstadoUsuario(idUsuario);
            return Json(new { exito = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListadoDocentes(string nombre="")
        {
            DocentesVm model = new DocentesVm()
            {
                AgregarEditarProfesorVm = new AgregarEditarProfesorVm(),
                Nombre = nombre,
                Profesores = _administracionService.GetListaProfesores(nombre)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AgregarEditarDocente(AgregarEditarProfesorVm agregarEditarProfesorVm)
        {
            Profesor profesor = new Profesor()
            {
                Codigo = agregarEditarProfesorVm.Codigo,
                Activo = true,
                Apellidos = agregarEditarProfesorVm.Apellidos,
                Nombres = agregarEditarProfesorVm.Nombres,
                FechaNacimiento = agregarEditarProfesorVm.FechaNacimiento,
                NumeroIdentificacion = agregarEditarProfesorVm.NumeroIdentificacion,
                Telefono = agregarEditarProfesorVm.Telefono
                
                 
            };

            _administracionService.AgregarEditarProfesor(profesor);
            return RedirectToAction("ListadoDocentes");
        }

        [HttpPost]
        public ActionResult GetDocenteEdit(int idProfesor)
        {
            Profesor profesor = _administracionService.GetProfesor(idProfesor);
            AgregarEditarProfesorVm agregarEditarProfesorVm = new AgregarEditarProfesorVm()
            {
                Telefono = profesor.Telefono,
                FechaNacimiento = profesor.FechaNacimiento,
                Apellidos = profesor.Apellidos,
                NumeroIdentificacion = profesor.NumeroIdentificacion,
                Nombres = profesor.Nombres,
                Codigo = profesor.Codigo,
                Activo = profesor.Activo

            };

            string stringPartial =
                this.ControllerContext.RenderPartialToString("~/Views/Administracion/_FrmDocente.cshtml", agregarEditarProfesorVm);

            return Json(new {partial = stringPartial}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ToggleEstadoDocente(int idProfesor)
        {
            _administracionService.ToggleEstadoProfesor(idProfesor);
            return Json(new {exito = true }, JsonRequestBehavior.AllowGet);
        }
    }
}