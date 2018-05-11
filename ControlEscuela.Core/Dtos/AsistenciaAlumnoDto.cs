using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEscuela.Core.Dtos
{
    public class AsistenciaAlumnoDto
    {
        /// <summary>
        /// Codigo del alumno para el cual se marca si asiste o no
        /// </summary>
        public int CodigAlumno { get; set; }

        /// <summary>
        /// Indica si el estudiante asiste o no
        /// </summary>
        public bool Asiste { get; set; }
    }
}
