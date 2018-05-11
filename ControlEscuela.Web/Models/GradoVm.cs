using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControlEscuela.Core.Model;
using ControlEscuela.Core.Model.Alumnos;
using ControlEscuela.Core.Model.Grados;

namespace ControlEscuela.Web.Models
{
    public class GradoVm
    {
        
        public string NombreBuscar { get; set; }

        public string NombreProfesor { get; set; }

        public Enums.Turno Turno { get; set; }

        public List<SeccionGrado> SeccionesGrado { get; set; }

        public AgregarEditarSeccionGradoVm AgregarEditarSeccionGradoVm { get; set; }
    }
}