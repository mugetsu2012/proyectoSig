using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControlEscuela.Web.Models
{
    public class AgregarEditarProfesorVm
    {
        public AgregarEditarProfesorVm()
        {
            FechaNacimiento = new DateTime(1800,1,1);
        }
        public int Codigo { get; set; }

        [Required(ErrorMessage = "La identificacion es requerida")]
        public string NumeroIdentificacion { get; set; }

        [Required(ErrorMessage = "El telefono es requerido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        public string Apellidos { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public bool Activo { get; set; }
        
    }
}