using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEscuela.Core.Dtos
{
    public class CalificarActividadDto
    {
        public int IdSeccionGrado { get; set; }

        public int IdActividad { get; set; }

        public List<NotaAlumnoDto> NotaAlumnoDtos { get; set; }
    }
}
