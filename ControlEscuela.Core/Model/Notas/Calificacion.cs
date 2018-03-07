using ControlEscuela.Core.Model.Alumnos;

namespace ControlEscuela.Core.Model.Notas
{
    public class Calificacion
    {
        /// <summary>
        /// Codigo de la actividad que se está calificando
        /// </summary>
        public int IdActividad { get; set; }

        /// <summary>
        /// Codigo del estudiante que es calificado
        /// </summary>
        public int IdEstudiante { get; set; }

        /// <summary>
        /// Codigo del profesor que califica
        /// </summary>
        public int IdProfesor { get; set; }

        /// <summary>
        /// Nota obtenida
        /// </summary>
        public decimal Nota { get; set; }

        /// <summary>
        /// Comentario del profesor
        /// </summary>
        public string Comentario { get; set; }

        public Actividad Actividad { get; set; }

        public Profesor Profesor { get; set; }

        public Estudiante Estudiante { get; set; }
    }
}
