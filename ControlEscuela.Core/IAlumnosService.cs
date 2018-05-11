using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscuela.Core.Dtos;
using ControlEscuela.Core.Model;
using ControlEscuela.Core.Model.Alumnos;

namespace ControlEscuela.Core
{
    public interface IAlumnosService: IDisposable
    {
        /// <summary>
        /// Metodo usado para crear/editar estudiantes
        /// </summary>
        /// <param name="estudiante"></param>
        void AgregarEditarEstudiante(Estudiante estudiante);

        /// <summary>
        /// Regresa una lista de estudiantes
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="nie"></param>
        /// <param name="seccionGrado"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        List<Estudiante> GetListaEstudiantes(string nombre="", string nie="", int seccionGrado=0, Enums.Estado estado = Enums.Estado.Todos);

        /// <summary>
        /// Recupera un estudiante por medio de su codigo
        /// </summary>
        /// <param name="idEstudiante"></param>
        /// <returns></returns>
        Estudiante GetEstudiante(int idEstudiante);

        /// <summary>
        /// Manda a desactivar un estudiante
        /// </summary>
        /// <param name="idEstudiante"></param>
        void ActivarDesactivarEstudiante(int idEstudiante);

        /// <summary>
        /// Guarda la asistencia para una fecha, grado y alumnos especificados.
        /// OJO: Este metodo no edita, por lo que no se debe poder modificar la asitencia
        /// </summary>
        /// <param name="marcarAsistenciaDto"></param>
        void MarcarAsistencia(MarcarAsistenciaDto marcarAsistenciaDto);

        /// <summary>
        /// Indica si ya existe una asistencia para la fecha y seccion grado marcados
        /// </summary>
        /// <param name="idSeccionGrado"></param>
        /// <param name="fechaMarcar"></param>
        /// <returns></returns>
        bool AsistenciaYaTomada(int idSeccionGrado, DateTime fechaMarcar);



    }
}
