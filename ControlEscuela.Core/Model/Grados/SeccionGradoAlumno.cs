using System;
using ControlEscuela.Core.Model.Alumnos;

namespace ControlEscuela.Core.Model.Grados
{
    public class SeccionGradoAlumno
    {
        /// <summary>
        /// Es llave
        /// </summary>
        public int IdSeccionGrado { get; set; }

        /// <summary>
        /// Es llave
        /// </summary>
        public int IdEstudiante { get; set; }

        public DateTime FechaIngreso { get; set; }

        public SeccionGrado SeccionGrado { get; set; }

        public Estudiante Estudiante { get; set; }
    }
}
