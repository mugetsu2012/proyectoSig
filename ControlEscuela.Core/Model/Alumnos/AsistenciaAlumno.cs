namespace ControlEscuela.Core.Model.Alumnos
{
    public class AsistenciaAlumno
    {
        /// <summary>
        /// Codigo de la asistencia
        /// </summary>
        public int IdAsistencia { get; set; }

        /// <summary>
        /// Codgo del alumno para el cual se toma a asistencia
        /// </summary>
        public int IdEstudiante { get; set; }

        /// <summary>
        /// Indica si el alumno asistio a clases
        /// </summary>
        public bool Asistio { get; set; }

        public Asistencia Asistencia { get; set; }

        public Estudiante Estudiante { get; set; }
    }
}
