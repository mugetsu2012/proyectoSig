using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEscuela.Core.Dtos
{
    public class NotaAlumnoDto
    {
        /// <summary>
        /// Code del estudiante
        /// </summary>
        public string Nie { get; set; }

        /// <summary>
        /// Nota que obtuvo
        /// </summary>
        public decimal Nota { get; set; }
    }
}
