using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControlEscuela.Core.Model.Alumnos;
using ControlEscuela.Core.Model.Grados;

namespace ControlEscuela.Web.Models
{
    public class ListadoAlumnosVm
    {
        public List<Estudiante> Estudiantes { get; set; }

        public string Nombre { get; set; }

        public string Nie { get; set; }

        public int IdSeccionGrado { get; set; }

        public List<SeccionGrado> SeccionesGrado { get; set; }
    }
}