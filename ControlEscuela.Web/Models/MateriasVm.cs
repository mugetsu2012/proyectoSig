using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControlEscuela.Core.Model.Asignaturas;

namespace ControlEscuela.Web.Models
{
    public class MateriasVm
    {
        public List<Asignatura> Asignaturas { get; set; }

        public string NombreBuscar { get; set; }

        public AgregarEditarMateriaVm AgregarEditarMateriaVm { get; set; }
    }
}