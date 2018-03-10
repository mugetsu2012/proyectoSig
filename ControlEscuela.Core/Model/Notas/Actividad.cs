using System;
using ControlEscuela.Core.Model.Asignaturas;
using ControlEscuela.Core.Model.Grados;

namespace ControlEscuela.Core.Model.Notas
{
    /// <summary>
    /// Entidad para una actividad evaluada
    /// </summary>
    public class Actividad
    {
        public int Codigo { get; set; }

        /// <summary>
        /// Nombre de la actividad
        /// </summary>
        public string Nombre { get; set; }

        public int IdAsignatura { get; set; }

        /// <summary>
        /// Seccion para la cual creamos la actividad
        /// </summary>
        public int IdSeccionGrado { get; set; }

        /// <summary>
        /// Indica la ponderacion
        /// </summary>
        public decimal Ponderacion { get; set; }

        public int IdPeriodo { get; set; }

        /// <summary>
        /// Fecha estimada para realizar la actividad
        /// </summary>
        public DateTime FechaRealizacion { get; set; }

        public Periodo Periodo { get; set; }

        public SeccionGrado SeccionGrado { get; set; }

        public Asignatura Asignatura { get; set; }
    }
}
