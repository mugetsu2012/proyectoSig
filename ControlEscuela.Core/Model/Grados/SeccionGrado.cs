using System;
using System.Collections.Generic;
using ControlEscuela.Core.Model.Alumnos;
using ControlEscuela.Core.Model.Asignaturas;
using ControlEscuela.Core.Model.Notas;

namespace ControlEscuela.Core.Model.Grados
{
    public class SeccionGrado
    {
        public int Codigo { get; set; }

        /// <summary>
        /// Codigo del grado para el cual estamos creando esta seccion
        /// </summary>
        public int IdGrado { get; set; }

        /// <summary>
        /// Tiene la letra correlativo, indica si es A,B,C,etc
        /// </summary>
        public string LetraCorrelativo { get; set; }

        /// <summary>
        /// Indica el turno de esta seccion grado
        /// </summary>
        public Enums.Turno Turno { get; set; }

        /// <summary>
        /// Codigo del profesor encargado de este grado
        /// </summary>
        public int IdProfesor { get; set; }

        public string TextoTurno
        {
            get { return Turno.ToString(); }
            set { Turno = (Enums.Turno)Enum.Parse(typeof(Enums.Turno), value); } 
        }

        public Grado Grado { get; set; }

        public Profesor Profesor { get; set; }

        public List<AsignaturaSeccionGrado> AsignaturaSeccionGrados { get; set; }

        public List<Actividad> Actividades { get; set; }

        public List<Estudiante> Estudiantes { get; set; }

        public string GetTextoNombre()
        {
            return IdGrado + "° " + LetraCorrelativo;
        }

    }
}
