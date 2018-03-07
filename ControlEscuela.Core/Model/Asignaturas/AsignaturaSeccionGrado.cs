using System.Collections.Generic;
using ControlEscuela.Core.Model.Alumnos;
using ControlEscuela.Core.Model.Grados;

namespace ControlEscuela.Core.Model.Asignaturas
{
    public class AsignaturaSeccionGrado
    {
        public int IdAsignatura { get; set; }

        public int IdSeccionGrado { get; set; }

        public int IdProfesor { get; set; }
        
        public Profesor Profesor { get; set; }

        public Asignatura Asignatura { get; set; }

        public SeccionGrado SeccionGrado { get; set; }

        /// <summary>
        /// Indica si está activo este registro
        /// </summary>
        public bool Activo { get; set; }

        public List<DiasAsignaturaSeccionGrado> DiasAsignaturaSeccionGrados { get; set; }
    }
}
