using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControlEscuela.Core.Model.Grados;

namespace ControlEscuela.Web.Models
{
    public class AgregarEditarAlumnoVm
    {
        public AgregarEditarAlumnoVm()
        {
            FechaNacimiento = new DateTime(1950,1,1);
            Activo = true;
        }
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

        public bool Activo { get; set; }

        public int Codigo { get; set; }

        public List<SeccionGrado> SeccionesGrado { get; set; }
        
    }
}