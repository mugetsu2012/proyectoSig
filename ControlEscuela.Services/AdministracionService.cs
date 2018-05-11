using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core;
using ControlEscuela.Core.Model;
using ControlEscuela.Core.Model.Alumnos;
using ControlEscuela.Core.Model.Usuarios;

namespace ControlEscuela.Services
{
    public class AdministracionService: IAdministracionService
    {
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IRepository<Profesor> _profesorRepository;
        private readonly IRepository<Rol> _rolRepository;

        public AdministracionService(IRepository<Usuario> usuarioRepository,
            IRepository<Profesor> profesorRepository, IRepository<Rol> rolRepository)
        {
            _usuarioRepository = usuarioRepository;
            _profesorRepository = profesorRepository;
            _rolRepository = rolRepository;
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
            _profesorRepository.Dispose();
            _rolRepository.Dispose();
        }

        public List<Usuario> GetListaUsuarios(string nombre = "", int idRol = 0, Enums.Estado estado = Enums.Estado.Todos)
        {
            List<Usuario> usuarios = _usuarioRepository.GetList(
                x =>  (x.IdUsuario.Contains(nombre) || nombre == "") &&
                     (x.IdRol == idRol || idRol == 0) && ((estado == Enums.Estado.Activo && x.Activo) ||
                                                          (estado == Enums.Estado.Inactivo && x.Activo == false) ||
                                                          (estado == Enums.Estado.Todos)),
                new Expression<Func<Usuario, object>>[]
                {
                    x => x.PersonaUsuario.Persona,
                    x => x.Rol
                });

            return usuarios;
        }

        public Usuario AgregarEditarUsuario(Usuario usuario, bool esEditar = false)
        {
            if (esEditar)
            {
                _usuarioRepository.Update(usuario);
            }
            else
            {
                _usuarioRepository.Insert(usuario);
            }
            return usuario;
        }

        public void ToggleEstadoUsuario(string idUsuario)
        {
            Usuario user = _usuarioRepository.FindByTracking(x => x.IdUsuario == idUsuario);
            user.Activo = !user.Activo;
            _usuarioRepository.SaveChanges();
        }

        public List<Profesor> GetListaProfesores(string nombre = "")
        {
            List<Profesor> profesores = _profesorRepository.GetList(x => x.Nombres.Contains(nombre) || nombre == "");
            return profesores;
        }

        public Profesor GetProfesor(int idProfesor)
        {
            return _profesorRepository.FindBy(x => x.Codigo == idProfesor);
        }

        public Usuario GetUsuario(string idUsuario)
        {
            return _usuarioRepository.FindBy(x => x.IdUsuario == idUsuario);
        }

        public Profesor AgregarEditarProfesor(Profesor profesor)
        {
            if (profesor.Codigo == 0)
            {
                _profesorRepository.Insert(profesor);
            }
            else
            {
                _profesorRepository.Update(profesor);
            }

            return profesor;
        }

        public void ToggleEstadoProfesor(int idProfesor)
        {
            Profesor profesor = _profesorRepository.FindByTracking(x => x.Codigo == idProfesor);
            profesor.Activo = !profesor.Activo;
            _profesorRepository.SaveChanges();
        }

        public List<Rol> GetRoles()
        {
            return _rolRepository.GetList(x => true);
        }
    }
}
