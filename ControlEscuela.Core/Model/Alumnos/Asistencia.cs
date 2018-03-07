using System;
using ControlEscuela.Core.Model.Grados;

namespace ControlEscuela.Core.Model.Alumnos
{
    public class Asistencia
    {
        public int Codigo { get; set; }

        /// <summary>
        /// Indica la fecha y hora de toma de asistencia
        /// </summary>
        public DateTime FechaIngreso { get; set; }

        /// <summary>
        /// Indica el codigo del grado y seccion exactos para cual se toma esta asistencia
        /// </summary>
        public int IdSeccionGrado { get; set; }

        /// <summary>
        /// Codigo del profesor que toma la asistencia ese dia
        /// </summary>
        public int IdProfesor { get; set; }


        public Profesor Profesor { get; set; }

        public SeccionGrado SeccionGrado { get; set; }
    }
}
