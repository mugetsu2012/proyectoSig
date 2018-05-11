using System;

namespace ControlEscuela.Core.Model.Notas
{
    public class Periodo
    {
        public int Codigo { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }
    }
}
