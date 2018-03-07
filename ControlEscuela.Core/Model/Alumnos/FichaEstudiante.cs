using System;
using ControlEscuela.Core.Model.Grados;

namespace ControlEscuela.Core.Model.Alumnos
{
    public class FichaEstudiante
    {
        public int Codigo { get; set; }

        public DateTime FechaIngreso { get; set; }

        /// <summary>
        /// Codigo del alumno para el cual se genera la ficha
        /// </summary>
        public int IdEstudiante { get; set; }

        /// <summary>
        /// Profesor que genero la ficha
        /// </summary>
        public int IdProfesor { get; set; }

        /// <summary>
        /// Indica a que grado iba el alumno al momento de generar este reporte
        /// </summary>
        public int IdSeccionGrado { get; set; }

        public SeccionGrado SeccionGrado { get; set; }

        /// <summary>
        /// Razón de generacion de la ficha
        /// </summary>
        public string Razon { get; set; }

        public Enums.TipoFalta TipoFalta { get; set; }

        public string TextoTipoFalta
        {
            get => TipoFalta.ToString();
            set => TipoFalta = (Enums.TipoFalta)Enum.Parse(typeof(Enums.TipoFalta), value);
        }

        public Estudiante Estudiante { get; set; }

        public Profesor Profesor { get; set; }
        
    }
}
