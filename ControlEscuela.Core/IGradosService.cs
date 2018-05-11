using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Model;
using ControlEscuela.Core.Model.Alumnos;
using ControlEscuela.Core.Model.Grados;

namespace ControlEscuela.Core
{
    public interface IGradosService:IDisposable
    {
        /// <summary>
        /// Obtiene una lista de grados por sus filtros
        /// </summary>
        /// <param name="nombreGrados"></param>
        /// <param name="profesor"></param>
        /// <param name="turno"></param>
        /// <returns></returns>
        List<SeccionGrado> GetListaGrados(string nombreGrados = "", string profesor = "", Enums.Turno turno = Enums.Turno.Todos);

        /// <summary>
        /// Permite agregar o editar una seccion grado
        /// </summary>
        /// <param name="seccionGrado"></param>
        /// <returns></returns>
        SeccionGrado AgregarEditarSeccionGrado(SeccionGrado seccionGrado);

        /// <summary>
        /// Me dice que letra es la que sigue para una lista de secciones grado
        /// </summary>
        /// <param name="idGrado"></param>
        /// <returns></returns>
        string GetSiguienteLetraCorrelativoSeccionGrado(int idGrado);

        /// <summary>
        /// Obtiene un grado por medio de su codigo
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        Grado GetGrado(int codigo);

        SeccionGrado GetSeccionGrado(int idSeccionGrado);

        /// <summary>
        /// Permite buscar estudiantes por medio de una seccion grado y una fecha de asistencia
        /// </summary>
        /// <param name="idSeccionGrado"></param>
        /// <param name="fechaAsistencia"></param>
        /// <returns></returns>
        List<AsistenciaAlumno> GetEstudiantesAsistencia(int idSeccionGrado, DateTime fechaAsistencia);


    }
}
