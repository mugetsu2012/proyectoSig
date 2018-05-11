using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControlEscuela.Core.Model.Alumnos;

namespace ControlEscuela.Web.Models
{
    public class DocentesVm
    {
        public string Nombre { get; set; }

        public AgregarEditarProfesorVm AgregarEditarProfesorVm { get; set; }

        public List<Profesor> Profesores { get; set; }
    }
}