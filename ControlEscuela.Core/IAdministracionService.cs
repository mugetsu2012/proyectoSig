using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model;
using ControlEscuela.Core.Model.Alumnos;
using ControlEscuela.Core.Model.Usuarios;

namespace ControlEscuela.Core
{
    public interface IAdministracionService: IDisposable
    {
        /// <summary>
        /// Filtro de usuarios
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="idRol"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        List<Usuario> GetListaUsuarios(string nombre = "", int idRol = 0, Enums.Estado estado = Enums.Estado.Todos);

        /// <summary>
        /// Agrega o edita un usuario segun sea el caso
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="esEditar"></param>
        /// <returns></returns>
        Usuario AgregarEditarUsuario(Usuario usuario, bool esEditar = false);
        
        void ToggleEstadoUsuario(string idUsuario);

        /// <summary>
        /// Regresa una lista de profesores
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        List<Profesor> GetListaProfesores(string nombre = "");

        /// <summary>
        /// Me regresa un profesor
        /// </summary>
        /// <param name="idProfesor"></param>
        /// <returns></returns>
        Profesor GetProfesor(int idProfesor);

        Usuario GetUsuario(string idUsuario);

        /// <summary>
        /// Agrega o edita al profesor basados en sus codigo
        /// </summary>
        /// <param name="profesor"></param>
        /// <returns></returns>
        Profesor AgregarEditarProfesor(Profesor profesor);

        /// <summary>
        /// Activa un profesor inactivo
        /// </summary>
        /// <param name="idProfesor"></param>
        void ToggleEstadoProfesor(int idProfesor);

        List<Rol> GetRoles();



    }
}
