using System;
using ControlEscuela.Core.Model.Grados;

namespace ControlEscuela.Core.Model.Alumnos
{
    public class ReporteMensualConducta
    {
        public int Codigo { get; set; }

        /// <summary>
        /// Codigo del estudiante
        /// </summary>
        public int IdEstudiante { get; set; }

        /// <summary>
        /// Codigo del profesor
        /// </summary>
        public int IdProfesor { get; set; }

        public DateTime FechaIngreso { get; set; }

        /// <summary>
        /// Comentario opcional del profesor
        /// </summary>
        public string Comentario { get; set; }

        /// <summary>
        /// Indica a que grado iba el alumno al momento de generar este reporte
        /// </summary>
        public int IdSeccionGrado { get; set; }

        public SeccionGrado SeccionGrado { get; set; }

        /// <summary>
        /// Tipo de conducta registrada
        /// </summary>
        public Enums.TipoConducta TipoConducta { get; set; }

        public string TextoConducta 
        {
            get => TipoConducta.ToString();
            set => TipoConducta = (Enums.TipoConducta)Enum.Parse(typeof(Enums.TipoConducta), value);
        }

        public Estudiante Estudiante { get; set; }

        public Profesor Profesor { get; set; }
    }
}
