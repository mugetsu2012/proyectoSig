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

        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaIngreso { get; set; }

        public bool Activo { get; set; }

        /// <summary>
        /// En base a la fecha de nacimiento calcula la edad de una persona
        /// </summary>
        /// <returns></returns>
        public int CalcularEdad()
        {
            // Save today's date.
            var hoy = DateTime.Today;

            // Calculate the age.
            var age = hoy.Year - FechaNacimiento.Year;
            // Go back to the year the person was born in case of a leap year
            if (FechaNacimiento > hoy.AddYears(-age)) age--;
            return age;
        }
    }
}
