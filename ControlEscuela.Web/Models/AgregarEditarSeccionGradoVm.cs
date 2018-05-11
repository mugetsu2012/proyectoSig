using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControlEscuela.Core.Model;
using ControlEscuela.Core.Model.Alumnos;
using ControlEscuela.Core.Model.Grados;

namespace ControlEscuela.Web.Models
{
    public class AgregarEditarSeccionGradoVm
    {
        public List<Profesor> Profesores { get; set; }

        public List<Grado> Grados { get; set; }

        public Enums.Turno Turno { get; set; }

        public int IdProfesor { get; set; }

        public int IdGrado { get; set; }

        public int Codigo { get; set; }
    }
}