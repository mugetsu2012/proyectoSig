using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControlEscuela.Core.Model.Grados;

namespace ControlEscuela.Web.Models
{
    public class AgregarEditarAlumnoVm
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

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public DateTime FechaNacimiento { get; set; }
        
    }
}