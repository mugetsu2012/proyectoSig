using System;

namespace ControlEscuela.Core.Model.Alumnos
{
    /// <summary>
    /// Entidad que representa a un estudiante o un profesor
    /// </summary>
    public class Persona
    {
        public int Codigo { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public int Edad { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string FechaIngreso { get; set; }

        public bool Activo { get; set; }
    }
}
