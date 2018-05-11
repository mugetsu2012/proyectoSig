using System;
using System.Collections.Generic;

namespace ControlEscuela.Core.Model.Grados
{
    public class Grado
    {
        public int Codigo { get; set; }

        /// <summary>
        /// Contine el grado
        /// </summary>
        public  Enums.NombresGrados NombreGrado { get; set; }

        public string TextoGrado    
        {
            get => NombreGrado.ToString();
            set => NombreGrado = (Enums.NombresGrados)Enum.Parse(typeof(Enums.NombresGrados), value);
        }

        /// <summary>
        /// Listado de secciones para este grado
        /// </summary>
        public List<SeccionGrado> SeccionesGrados { get; set; }
    }
}
