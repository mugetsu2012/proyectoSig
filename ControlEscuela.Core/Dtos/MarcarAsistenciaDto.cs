using System;
using System.Collections.Generic;

namespace ControlEscuela.Core.Dtos
{
    /// <summary>
    /// Clase para marcar asistencia
    /// </summary>
    public class MarcarAsistenciaDto
    {
        /// <summary>
        /// Fecha para la cual marcamos la asistencia
        /// </summary>
        public DateTime FechaAsistencia { get; set; }

        /// <summary>
        /// Seccion grado para la cual se marca la asistencia
        /// </summary>
        public int IdSeccionGrado { get; set; }

        /// <summary>
        /// Profe que toma la asistencia
        /// </summary>
        public int IdProfesor { get; set; }

        /// <summary>
        /// Lista de asistencias para los alumnos
        /// </summary>
        public List<AsistenciaAlumnoDto> AsistenciaAlumnoDtos { get; set; }
    }
}
