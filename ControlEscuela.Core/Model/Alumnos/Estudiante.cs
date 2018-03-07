using ControlEscuela.Core.Model.Grados;

namespace ControlEscuela.Core.Model.Alumnos
{
    public class Estudiante: Persona
    {
        /// <summary>
        /// Numero de indentificacion
        /// </summary>
        public string Nie { get; set; }

        public string NombreEncargado { get; set; }

        public string TelefonoEncargado { get; set; }

        public string Direccion { get; set; }

        /// <summary>
        /// Codigo de la seccion y grado al que asiste el alumno actualmente
        /// </summary>
        public int IdSeccionGrado { get; set; }

        public SeccionGrado SeccionGrado { get; set; }
    }
}
